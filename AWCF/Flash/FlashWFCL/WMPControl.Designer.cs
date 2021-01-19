namespace PlayerWFCL {
	partial class WMPControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMPControl));
			this.WMPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			((System.ComponentModel.ISupportInitialize)(this.WMPlayer)).BeginInit();
			this.SuspendLayout();
			// 
			// WMPlayer
			// 
			this.WMPlayer.Enabled = true;
			this.WMPlayer.Location = new System.Drawing.Point(0, 0);
			this.WMPlayer.Name = "WMPlayer";
			this.WMPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMPlayer.OcxState")));
			this.WMPlayer.Size = new System.Drawing.Size(960, 540);
			this.WMPlayer.TabIndex = 0;
			this.WMPlayer.UseWaitCursor = true;
			// 
			// WMPControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.WMPlayer);
			this.Name = "WMPControl";
			this.Size = new System.Drawing.Size(960, 540);
			((System.ComponentModel.ISupportInitialize)(this.WMPlayer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public AxWMPLib.AxWindowsMediaPlayer WMPlayer;
	}
}
