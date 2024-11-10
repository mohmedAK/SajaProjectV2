namespace SajaProjectV2.View.DataForms
{
    partial class FRM_Show_All_Projects
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Show_All_Projects));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gcProjectInformation = new DevExpress.XtraGrid.GridControl();
            this.cLSProjectInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvProjectInformation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinshDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repFallow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCosts = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colProjectId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcProjectInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLSProjectInformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjectInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repFallow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCosts)).BeginInit();
            this.SuspendLayout();
            // 
            // gcProjectInformation
            // 
            this.gcProjectInformation.DataSource = this.cLSProjectInformationBindingSource;
            this.gcProjectInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProjectInformation.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcProjectInformation.Location = new System.Drawing.Point(0, 0);
            this.gcProjectInformation.MainView = this.gvProjectInformation;
            this.gcProjectInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcProjectInformation.Name = "gcProjectInformation";
            this.gcProjectInformation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEdit,
            this.repDelete,
            this.repFallow,
            this.repCosts});
            this.gcProjectInformation.Size = new System.Drawing.Size(897, 550);
            this.gcProjectInformation.TabIndex = 15;
            this.gcProjectInformation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProjectInformation});
            // 
            // cLSProjectInformationBindingSource
            // 
            this.cLSProjectInformationBindingSource.DataSource = typeof(SajaProjectV2.Model.CLS_ProjectInformation);
            // 
            // gvProjectInformation
            // 
            this.gvProjectInformation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.gvProjectInformation.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvProjectInformation.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvProjectInformation.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvProjectInformation.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvProjectInformation.Appearance.Row.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.gvProjectInformation.Appearance.Row.Options.UseFont = true;
            this.gvProjectInformation.Appearance.Row.Options.UseTextOptions = true;
            this.gvProjectInformation.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvProjectInformation.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvProjectInformation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProId,
            this.colProName,
            this.colOwner,
            this.colValue,
            this.colLocation,
            this.colStartDate,
            this.colFinshDate,
            this.colFallow,
            this.colEdit,
            this.colDelete,
            this.colCost});
            this.gvProjectInformation.DetailHeight = 284;
            this.gvProjectInformation.GridControl = this.gcProjectInformation;
            this.gvProjectInformation.Name = "gvProjectInformation";
            this.gvProjectInformation.OptionsView.ShowGroupPanel = false;
            this.gvProjectInformation.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvProjectInformation_CustomRowCellEdit);
            this.gvProjectInformation.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvProjectInformation_CustomUnboundColumnData);
            // 
            // colProId
            // 
            this.colProId.Caption = "ID";
            this.colProId.FieldName = "Id";
            this.colProId.Name = "colProId";
            this.colProId.OptionsColumn.AllowEdit = false;
            this.colProId.OptionsColumn.AllowFocus = false;
            this.colProId.OptionsColumn.AllowMove = false;
            this.colProId.Visible = true;
            this.colProId.VisibleIndex = 0;
            // 
            // colProName
            // 
            this.colProName.Caption = "Project";
            this.colProName.FieldName = "ProjectName";
            this.colProName.MinWidth = 21;
            this.colProName.Name = "colProName";
            this.colProName.OptionsColumn.AllowEdit = false;
            this.colProName.OptionsColumn.AllowFocus = false;
            this.colProName.OptionsColumn.AllowMove = false;
            this.colProName.Visible = true;
            this.colProName.VisibleIndex = 1;
            this.colProName.Width = 72;
            // 
            // colOwner
            // 
            this.colOwner.Caption = "Owner";
            this.colOwner.FieldName = "OwnerName";
            this.colOwner.MinWidth = 21;
            this.colOwner.Name = "colOwner";
            this.colOwner.OptionsColumn.AllowEdit = false;
            this.colOwner.OptionsColumn.AllowFocus = false;
            this.colOwner.OptionsColumn.AllowMove = false;
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 2;
            // 
            // colValue
            // 
            this.colValue.Caption = "Value";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.OptionsColumn.AllowFocus = false;
            this.colValue.OptionsColumn.AllowMove = false;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 6;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.OptionsColumn.AllowEdit = false;
            this.colLocation.OptionsColumn.AllowFocus = false;
            this.colLocation.OptionsColumn.AllowMove = false;
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 5;
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "Start";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsColumn.AllowEdit = false;
            this.colStartDate.OptionsColumn.AllowFocus = false;
            this.colStartDate.OptionsColumn.AllowMove = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 3;
            // 
            // colFinshDate
            // 
            this.colFinshDate.Caption = "Finsh";
            this.colFinshDate.FieldName = "FinishDate";
            this.colFinshDate.Name = "colFinshDate";
            this.colFinshDate.OptionsColumn.AllowEdit = false;
            this.colFinshDate.OptionsColumn.AllowFocus = false;
            this.colFinshDate.OptionsColumn.AllowMove = false;
            this.colFinshDate.Visible = true;
            this.colFinshDate.VisibleIndex = 4;
            // 
            // colFallow
            // 
            this.colFallow.Caption = "Fallow up";
            this.colFallow.ColumnEdit = this.repFallow;
            this.colFallow.Name = "colFallow";
            this.colFallow.Visible = true;
            this.colFallow.VisibleIndex = 8;
            // 
            // repFallow
            // 
            this.repFallow.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repFallow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repFallow.Name = "repFallow";
            this.repFallow.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repFallow.Click += new System.EventHandler(this.repFallow_Click);
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Edit ";
            this.colEdit.ColumnEdit = this.repEdit;
            this.colEdit.MinWidth = 21;
            this.colEdit.Name = "colEdit";
            this.colEdit.OptionsColumn.AllowMove = false;
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 9;
            this.colEdit.Width = 81;
            // 
            // repEdit
            // 
            this.repEdit.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repEdit.Name = "repEdit";
            this.repEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repEdit.Click += new System.EventHandler(this.repEdit_Click);
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Delete";
            this.colDelete.ColumnEdit = this.repDelete;
            this.colDelete.MinWidth = 21;
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.AllowMove = false;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 10;
            this.colDelete.Width = 81;
            // 
            // repDelete
            // 
            this.repDelete.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.repDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repDelete.Name = "repDelete";
            this.repDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repDelete.Click += new System.EventHandler(this.repDelete_Click);
            // 
            // colCost
            // 
            this.colCost.Caption = "Cost";
            this.colCost.ColumnEdit = this.repCosts;
            this.colCost.Name = "colCost";
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 7;
            // 
            // repCosts
            // 
            this.repCosts.AutoHeight = false;
            editorButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions4.Image")));
            this.repCosts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repCosts.Name = "repCosts";
            this.repCosts.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repCosts.Click += new System.EventHandler(this.repCosts_Click);
            // 
            // colProjectId
            // 
            this.colProjectId.FieldName = "Id";
            this.colProjectId.MinWidth = 21;
            this.colProjectId.Name = "colProjectId";
            this.colProjectId.OptionsColumn.AllowEdit = false;
            this.colProjectId.OptionsColumn.AllowFocus = false;
            this.colProjectId.OptionsColumn.AllowMove = false;
            this.colProjectId.Width = 80;
            // 
            // FRM_Show_All_Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 550);
            this.Controls.Add(this.gcProjectInformation);
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FRM_Show_All_Projects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Projects";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_Show_All_Projects_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gcProjectInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLSProjectInformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProjectInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repFallow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCosts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcProjectInformation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProjectInformation;
        private DevExpress.XtraGrid.Columns.GridColumn colProName;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectId;
        private DevExpress.XtraGrid.Columns.GridColumn colProId;
        private System.Windows.Forms.BindingSource cLSProjectInformationBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFinshDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFallow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repFallow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repCosts;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
    }
}