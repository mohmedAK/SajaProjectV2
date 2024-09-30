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
            this.gcWage = new DevExpress.XtraGrid.GridControl();
            this.cLSProjectInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvWage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colProjectId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinshDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcWage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLSProjectInformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // gcWage
            // 
            this.gcWage.DataSource = this.cLSProjectInformationBindingSource;
            this.gcWage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWage.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcWage.Location = new System.Drawing.Point(0, 0);
            this.gcWage.MainView = this.gvWage;
            this.gcWage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcWage.Name = "gcWage";
            this.gcWage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEdit,
            this.repDelete});
            this.gcWage.Size = new System.Drawing.Size(551, 550);
            this.gcWage.TabIndex = 15;
            this.gcWage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWage});
            // 
            // cLSProjectInformationBindingSource
            // 
            this.cLSProjectInformationBindingSource.DataSource = typeof(SajaProjectV2.Model.CLS_ProjectInformation);
            // 
            // gvWage
            // 
            this.gvWage.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.gvWage.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvWage.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvWage.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvWage.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvWage.Appearance.Row.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.gvWage.Appearance.Row.Options.UseFont = true;
            this.gvWage.Appearance.Row.Options.UseTextOptions = true;
            this.gvWage.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvWage.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvWage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProId,
            this.colProName,
            this.colOwner,
            this.colValue,
            this.colLocation,
            this.colStartDate,
            this.colFinshDate,
            this.colEdit,
            this.colDelete});
            this.gvWage.DetailHeight = 284;
            this.gvWage.GridControl = this.gcWage;
            this.gvWage.Name = "gvWage";
            this.gvWage.OptionsView.ShowGroupPanel = false;
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
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 6;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 5;
            // 
            // colEdit
            // 
            this.colEdit.ColumnEdit = this.repEdit;
            this.colEdit.MinWidth = 21;
            this.colEdit.Name = "colEdit";
            this.colEdit.OptionsColumn.AllowMove = false;
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 7;
            this.colEdit.Width = 81;
            // 
            // repEdit
            // 
            this.repEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repEdit.Name = "repEdit";
            this.repEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repEdit.Click += new System.EventHandler(this.repEdit_Click);
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repDelete;
            this.colDelete.MinWidth = 21;
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.AllowMove = false;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 8;
            this.colDelete.Width = 81;
            // 
            // repDelete
            // 
            this.repDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repDelete.Name = "repDelete";
            this.repDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repDelete.Click += new System.EventHandler(this.repDelete_Click);
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
            // colStartDate
            // 
            this.colStartDate.Caption = "Start";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 3;
            // 
            // colFinshDate
            // 
            this.colFinshDate.Caption = "Finsh";
            this.colFinshDate.FieldName = "FinishDate";
            this.colFinshDate.Name = "colFinshDate";
            this.colFinshDate.Visible = true;
            this.colFinshDate.VisibleIndex = 4;
            // 
            // FRM_Show_All_Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 550);
            this.Controls.Add(this.gcWage);
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FRM_Show_All_Projects";
            this.Text = "FRM_Show_All_Projects";
            ((System.ComponentModel.ISupportInitialize)(this.gcWage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLSProjectInformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcWage;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWage;
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
    }
}