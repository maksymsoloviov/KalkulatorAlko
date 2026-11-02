using System;
using System.Drawing;
using System.Windows.Forms;

namespace KalkulatorAlko
{
    public partial class Form1 : Form
    {
        private TextBox txtWielkosc;
        private TextBox txtProcent;
        private TextBox txtIlosc;
        private Button btnOblicz;
        private Label lblWynikNapoj;
        private Label lblWynikSpirytus;

        public Form1()
        {
            InitializeComponent();
            BudujPodstawoweGUI();
        }

        private void BudujPodstawoweGUI()
        {
            this.Text = "Kalkulator Procentowy - Lab 02";
            this.Size = new Size(420, 330);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl1 = new Label { Text = "Wielkość naczynia (ml):", Location = new Point(20, 25), AutoSize = true };
            txtWielkosc = new TextBox { Location = new Point(220, 22), Width = 150 };

            Label lbl2 = new Label { Text = "Zawartość spirytusu (%):", Location = new Point(20, 65), AutoSize = true };
            txtProcent = new TextBox { Location = new Point(220, 62), Width = 150 };

            Label lbl3 = new Label { Text = "Ilość sztuk naczynia:", Location = new Point(20, 105), AutoSize = true };
            txtIlosc = new TextBox { Location = new Point(220, 102), Width = 150, Text = "1" };

            btnOblicz = new Button { Text = "Oblicz", Location = new Point(20, 150), Size = new Size(350, 35) };
            btnOblicz.Click += BtnOblicz_Click;

            lblWynikNapoj = new Label { Text = "Objętość napoju: 0 ml", Location = new Point(20, 205), AutoSize = true, Font = new Font(Font, FontStyle.Bold) };
            lblWynikSpirytus = new Label { Text = "Objętość czystego spirytusu: 0 ml", Location = new Point(20, 235), AutoSize = true, Font = new Font(Font, FontStyle.Bold) };

            this.Controls.AddRange(new Control[] { lbl1, txtWielkosc, lbl2, txtProcent, lbl3, txtIlosc, btnOblicz, lblWynikNapoj, lblWynikSpirytus });
        }

        private void BtnOblicz_Click(object sender, EventArgs e)
        {
            try
            {
                double wielkosc = double.Parse(txtWielkosc.Text.Replace('.', ','));
                double procent = double.Parse(txtProcent.Text.Replace('.', ','));
                int ilosc = int.Parse(txtIlosc.Text);

                double objNapoju = AlcoholCalculator.ObliczObjetoscNapoju(wielkosc, ilosc);
                double objSpirytusu = AlcoholCalculator.ObliczObjetoscSpirytusu(wielkosc, procent, ilosc);

                lblWynikNapoj.Text = $"Objętość napoju: {objNapoju} ml";
                lblWynikSpirytus.Text = $"Objętość czystego spirytusu: {objSpirytusu} ml";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
