namespace EmployeePro.View.DataForms
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
            this.gvWage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // gcWage
            // 
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
            // gvWage
            // 
            this.gvWage.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvWage.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvWage.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvWage.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvWage.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvWage.Appearance.Row.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvWage.Appearance.Row.Options.UseFont = true;
            this.gvWage.Appearance.Row.Options.UseTextOptions = true;
            this.gvWage.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvWage.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvWage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpId,
            this.colId,
            this.colEntryDate,
            this.colSalary,
            this.colDiscount,
            this.colTotal,
            this.colEdit,
            this.colDelete});
            this.gvWage.DetailHeight = 284;
            this.gvWage.GridControl = this.gcWage;
            this.gvWage.Name = "gvWage";
            this.gvWage.OptionsView.ShowGroupPanel = false;
            // 
            // colEmpId
            // 
            this.colEmpId.FieldName = "EmpId";
            this.colEmpId.MinWidth = 21;
            this.colEmpId.Name = "colEmpId";
            this.colEmpId.OptionsColumn.AllowEdit = false;
            this.colEmpId.OptionsColumn.AllowFocus = false;
            this.colEmpId.OptionsColumn.AllowMove = false;
            this.colEmpId.Width = 80;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
            this.colId.OptionsColumn.AllowMove = false;
            this.colId.Width = 80;
            // 
            // colEntryDate
            // 
            this.colEntryDate.FieldName = "EntryDate";
            this.colEntryDate.MinWidth = 21;
            this.colEntryDate.Name = "colEntryDate";
            this.colEntryDate.OptionsColumn.AllowEdit = false;
            this.colEntryDate.OptionsColumn.AllowFocus = false;
            this.colEntryDate.OptionsColumn.AllowMove = false;
            this.colEntryDate.Visible = true;
            this.colEntryDate.VisibleIndex = 0;
            this.colEntryDate.Width = 102;
            // 
            // colSalary
            // 
            this.colSalary.FieldName = "Salary";
            this.colSalary.MinWidth = 21;
            this.colSalary.Name = "colSalary";
            this.colSalary.OptionsColumn.AllowEdit = false;
            this.colSalary.OptionsColumn.AllowFocus = false;
            this.colSalary.OptionsColumn.AllowMove = false;
            this.colSalary.Visible = true;
            this.colSalary.VisibleIndex = 1;
            this.colSalary.Width = 72;
            // 
            // colDiscount
            // 
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.MinWidth = 21;
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.OptionsColumn.AllowEdit = false;
            this.colDiscount.OptionsColumn.AllowFocus = false;
            this.colDiscount.OptionsColumn.AllowMove = false;
            this.colDiscount.Visible = true;
            this.colDiscount.VisibleIndex = 2;
            this.colDiscount.Width = 72;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.MinWidth = 21;
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.AllowFocus = false;
            this.colTotal.OptionsColumn.AllowMove = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            // 
            // colEdit
            // 
            this.colEdit.ColumnEdit = this.repEdit;
            this.colEdit.MinWidth = 21;
            this.colEdit.Name = "colEdit";
            this.colEdit.OptionsColumn.AllowMove = false;
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 4;
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
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repDelete;
            this.colDelete.MinWidth = 21;
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.AllowMove = false;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 5;
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
            ((System.ComponentModel.ISupportInitialize)(this.gvWage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcWage;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWage;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpId;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repDelete;
    }
}