namespace SajaProjectV2.View.DataForms
{
    partial class FRM_BasicProjectData
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
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUsers = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.sbShowProjects = new DevExpress.XtraEditors.SimpleButton();
            this.sbNewProject = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnUsers);
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Controls.Add(this.sbShowProjects);
            this.groupControl1.Controls.Add(this.sbNewProject);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(537, 362);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Main Menu";
            // 
            // btnUsers
            // 
            this.btnUsers.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnUsers.Appearance.Options.UseFont = true;
            this.btnUsers.Location = new System.Drawing.Point(144, 89);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(238, 43);
            this.btnUsers.TabIndex = 10;
            this.btnUsers.Text = "Users";
            this.btnUsers.Visible = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(144, 236);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(238, 43);
            this.simpleButton4.TabIndex = 9;
            this.simpleButton4.Text = "Back";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // sbShowProjects
            // 
            this.sbShowProjects.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sbShowProjects.Appearance.Options.UseFont = true;
            this.sbShowProjects.Location = new System.Drawing.Point(144, 187);
            this.sbShowProjects.Name = "sbShowProjects";
            this.sbShowProjects.Size = new System.Drawing.Size(238, 43);
            this.sbShowProjects.TabIndex = 7;
            this.sbShowProjects.Text = "Show Projects";
            this.sbShowProjects.Click += new System.EventHandler(this.sbShowProjects_Click);
            // 
            // sbNewProject
            // 
            this.sbNewProject.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sbNewProject.Appearance.Options.UseFont = true;
            this.sbNewProject.Location = new System.Drawing.Point(144, 138);
            this.sbNewProject.Name = "sbNewProject";
            this.sbNewProject.Size = new System.Drawing.Size(238, 43);
            this.sbNewProject.TabIndex = 6;
            this.sbNewProject.Text = "New Project Data";
            this.sbNewProject.Click += new System.EventHandler(this.sbNewProject_Click);
            // 
            // FRM_BasicProjectData
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 362);
            this.Controls.Add(this.groupControl1);
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(545, 390);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(545, 386);
            this.Name = "FRM_BasicProjectData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_BasicProjectData_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton sbShowProjects;
        private DevExpress.XtraEditors.SimpleButton sbNewProject;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton btnUsers;
    }
}