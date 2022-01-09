namespace PlayerWFCL {
	partial class FlushControl {
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlushControl));
			this.SFPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
			((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).BeginInit();
			this.SuspendLayout();
			// 
			// SFPlayer
			// 
			this.SFPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SFPlayer.Enabled = true;
			this.SFPlayer.Location = new System.Drawing.Point(0, 0);
			this.SFPlayer.Name = "SFPlayer";
			this.SFPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SFPlayer.OcxState")));
			this.SFPlayer.Size = new System.Drawing.Size(960, 540);
			this.SFPlayer.TabIndex = 0;
			this.SFPlayer.UseWaitCursor = true;
			// 
			// FlushControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SFPlayer);
			this.Name = "FlushControl";
			this.Size = new System.Drawing.Size(960, 540);
			((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public AxShockwaveFlashObjects.AxShockwaveFlash SFPlayer;
	}
}
