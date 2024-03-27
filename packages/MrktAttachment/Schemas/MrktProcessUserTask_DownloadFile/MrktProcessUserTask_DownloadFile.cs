using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using Terrasoft.Core.Entities;
using Terrasoft.File;
using Terrasoft.File.Abstractions;

namespace Terrasoft.Core.Process.Configuration
{
	#region Class: MrktProcessUserTask_ResponseParser

	/// <exclude/>
	public partial class MrktProcessUserTask_DownloadFile
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context){
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByUId(EntityObject);
			string schemaName = schema.Name;

			using (HttpClient client = new HttpClient()) {
				//Should keep this in SysSetting, also consider creating one HttpClient per creatio.
				client.BaseAddress = new Uri("https://mgsdev.uaenorth.cloudapp.azure.com");

				//Set file number from input
				string uriStr = $"/MGSCS/OTCSService.asmx/DocDownload?ObjID={MrktObjId}";

				HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, new Uri(uriStr, UriKind.Relative));
				HttpResponseMessage response = client.SendAsync(msg).ConfigureAwait(false).GetAwaiter().GetResult();
				byte[] bytes = response.Content.ReadAsByteArrayAsync().ConfigureAwait(false).GetAwaiter().GetResult();

				//TODO: Add Error Handling When content-disposition header is missing
				string contentDispositionHeader
					= response.Content.Headers.GetValues("content-disposition").FirstOrDefault();

				string fileName = string.Empty;
				if (!string.IsNullOrWhiteSpace(contentDispositionHeader) &&
					contentDispositionHeader.StartsWith("attachment; filename=")) {
					fileName = contentDispositionHeader?.Split(';')[1].Split('=')[1];
				}

				//Set Returning value
				FileId = Guid.NewGuid();

				// Create new instance of FileLocator
				EntityFileLocator fileLocator = new EntityFileLocator($"{schemaName}File", FileId);

				// Create new IFile object for the file.
				IFile file = UserConnection.CreateFile(fileLocator);
				file.Name = fileName;

				//Set attribute to (ContactId, "GUID")
				file.SetAttribute($"{schemaName}Id", EntityId);
				file.Save();

				using (MemoryStream stream = new MemoryStream(bytes)) {
					//Save file in fileStorage (may be db, may be S3 bucket)
					file.Write(stream, FileWriteOptions.SinglePart); // FileWriteOptions.SinglePart means whole file
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override void CancelExecuting(params object[] parameters){
			base.CancelExecuting(parameters);
		}

		public override bool CompleteExecuting(params object[] parameters){
			return base.CompleteExecuting(parameters);
		}

		public override string GetExecutionData(){
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData(){
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion
}