﻿namespace SharpMapSource
{
    partial class LayerInfo
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
            this._layersDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._layersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _layersDataGrid
            // 
            this._layersDataGrid.AllowUserToAddRows = false;
            this._layersDataGrid.AllowUserToDeleteRows = false;
            this._layersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._layersDataGrid.Location = new System.Drawing.Point(12, 12);
            this._layersDataGrid.Name = "_layersDataGrid";
            this._layersDataGrid.ReadOnly = true;
            this._layersDataGrid.RowHeadersVisible = false;
            this._layersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._layersDataGrid.Size = new System.Drawing.Size(824, 334);
            this._layersDataGrid.TabIndex = 0;
            // 
            // LayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 358);
            this.Controls.Add(this._layersDataGrid);
            this.Name = "LayerInfo";
            this.Text = "LayerInfo";
            this.Load += new System.EventHandler(this.LayerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this._layersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _layersDataGrid;
    }
}