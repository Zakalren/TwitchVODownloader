namespace TwitchVODownloader
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBox1080p60 = new System.Windows.Forms.RadioButton();
            this.chkBox720p60 = new System.Windows.Forms.RadioButton();
            this.chkBox720p = new System.Windows.Forms.RadioButton();
            this.chkBox480p = new System.Windows.Forms.RadioButton();
            this.chkBox360p = new System.Windows.Forms.RadioButton();
            this.chkBox160p = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVideosize = new System.Windows.Forms.Label();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxLink
            // 
            this.txtBoxLink.Location = new System.Drawing.Point(12, 38);
            this.txtBoxLink.Name = "txtBoxLink";
            this.txtBoxLink.Size = new System.Drawing.Size(522, 21);
            this.txtBoxLink.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "다시보기 영상 주소";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(312, 220);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(222, 41);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "다운로드";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBox1080p60);
            this.groupBox1.Controls.Add(this.chkBox720p60);
            this.groupBox1.Controls.Add(this.chkBox720p);
            this.groupBox1.Controls.Add(this.chkBox480p);
            this.groupBox1.Controls.Add(this.chkBox360p);
            this.groupBox1.Controls.Add(this.chkBox160p);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "화질";
            // 
            // chkBox1080p60
            // 
            this.chkBox1080p60.AutoSize = true;
            this.chkBox1080p60.Location = new System.Drawing.Point(373, 26);
            this.chkBox1080p60.Name = "chkBox1080p60";
            this.chkBox1080p60.Size = new System.Drawing.Size(90, 20);
            this.chkBox1080p60.TabIndex = 5;
            this.chkBox1080p60.Text = "1080p60";
            this.chkBox1080p60.UseVisualStyleBackColor = true;
            // 
            // chkBox720p60
            // 
            this.chkBox720p60.AutoSize = true;
            this.chkBox720p60.Checked = true;
            this.chkBox720p60.Location = new System.Drawing.Point(286, 26);
            this.chkBox720p60.Name = "chkBox720p60";
            this.chkBox720p60.Size = new System.Drawing.Size(81, 20);
            this.chkBox720p60.TabIndex = 4;
            this.chkBox720p60.TabStop = true;
            this.chkBox720p60.Text = "720p60";
            this.chkBox720p60.UseVisualStyleBackColor = true;
            // 
            // chkBox720p
            // 
            this.chkBox720p.AutoSize = true;
            this.chkBox720p.Location = new System.Drawing.Point(217, 26);
            this.chkBox720p.Name = "chkBox720p";
            this.chkBox720p.Size = new System.Drawing.Size(63, 20);
            this.chkBox720p.TabIndex = 3;
            this.chkBox720p.Text = "720p";
            this.chkBox720p.UseVisualStyleBackColor = true;
            // 
            // chkBox480p
            // 
            this.chkBox480p.AutoSize = true;
            this.chkBox480p.Location = new System.Drawing.Point(147, 26);
            this.chkBox480p.Name = "chkBox480p";
            this.chkBox480p.Size = new System.Drawing.Size(64, 20);
            this.chkBox480p.TabIndex = 2;
            this.chkBox480p.Text = "480p";
            this.chkBox480p.UseVisualStyleBackColor = true;
            // 
            // chkBox360p
            // 
            this.chkBox360p.AutoSize = true;
            this.chkBox360p.Location = new System.Drawing.Point(78, 26);
            this.chkBox360p.Name = "chkBox360p";
            this.chkBox360p.Size = new System.Drawing.Size(63, 20);
            this.chkBox360p.TabIndex = 1;
            this.chkBox360p.Text = "360p";
            this.chkBox360p.UseVisualStyleBackColor = true;
            // 
            // chkBox160p
            // 
            this.chkBox160p.AutoSize = true;
            this.chkBox160p.Location = new System.Drawing.Point(9, 26);
            this.chkBox160p.Name = "chkBox160p";
            this.chkBox160p.Size = new System.Drawing.Size(63, 20);
            this.chkBox160p.TabIndex = 0;
            this.chkBox160p.Text = "160p";
            this.chkBox160p.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "예상되는 파일 용량:";
            // 
            // lblVideosize
            // 
            this.lblVideosize.AutoSize = true;
            this.lblVideosize.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVideosize.Location = new System.Drawing.Point(241, 229);
            this.lblVideosize.Name = "lblVideosize";
            this.lblVideosize.Size = new System.Drawing.Size(51, 16);
            this.lblVideosize.TabIndex = 5;
            this.lblVideosize.Text = "None";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(12, 97);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.ReadOnly = true;
            this.txtBoxPath.Size = new System.Drawing.Size(467, 21);
            this.txtBoxPath.TabIndex = 7;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(485, 97);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(49, 23);
            this.btnPath.TabIndex = 8;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "영상이 저장될 폴더";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 291);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.lblVideosize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxLink);
            this.Name = "Main";
            this.Text = "VOD Downloader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton chkBox1080p60;
        private System.Windows.Forms.RadioButton chkBox720p60;
        private System.Windows.Forms.RadioButton chkBox720p;
        private System.Windows.Forms.RadioButton chkBox480p;
        private System.Windows.Forms.RadioButton chkBox360p;
        private System.Windows.Forms.RadioButton chkBox160p;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVideosize;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label label3;
    }
}

