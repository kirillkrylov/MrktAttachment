namespace Terrasoft.Core.Process.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: MrktProcessUserTask_DownloadFile

	[DesignModeProperty(Name = "MrktObjId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "24301387f87a4159a4268247c3f8a12e", CaptionResourceItem = "Parameters.MrktObjId.Caption", DescriptionResourceItem = "Parameters.MrktObjId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityObject", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "24301387f87a4159a4268247c3f8a12e", CaptionResourceItem = "Parameters.EntityObject.Caption", DescriptionResourceItem = "Parameters.EntityObject.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "24301387f87a4159a4268247c3f8a12e", CaptionResourceItem = "Parameters.EntityId.Caption", DescriptionResourceItem = "Parameters.EntityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FileId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "24301387f87a4159a4268247c3f8a12e", CaptionResourceItem = "Parameters.FileId.Caption", DescriptionResourceItem = "Parameters.FileId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class MrktProcessUserTask_DownloadFile : ProcessUserTask
	{

		#region Constructors: Public

		public MrktProcessUserTask_DownloadFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("24301387-f87a-4159-a426-8247c3f8a12e");
		}

		#endregion

		#region Properties: Public

		public virtual string MrktObjId {
			get;
			set;
		}

		public virtual Guid EntityObject {
			get;
			set;
		}

		public virtual Guid EntityId {
			get;
			set;
		}

		public virtual Guid FileId {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("MrktObjId")) {
					writer.WriteValue("MrktObjId", MrktObjId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("EntityObject")) {
					writer.WriteValue("EntityObject", EntityObject, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("EntityId")) {
					writer.WriteValue("EntityId", EntityId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("FileId")) {
					writer.WriteValue("FileId", FileId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "MrktObjId":
					if (!UseFlowEngineMode) {
						break;
					}
					MrktObjId = reader.GetStringValue();
				break;
				case "EntityObject":
					if (!UseFlowEngineMode) {
						break;
					}
					EntityObject = reader.GetGuidValue();
				break;
				case "EntityId":
					if (!UseFlowEngineMode) {
						break;
					}
					EntityId = reader.GetGuidValue();
				break;
				case "FileId":
					if (!UseFlowEngineMode) {
						break;
					}
					FileId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

