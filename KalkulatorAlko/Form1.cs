using System;
using System.Drawing;
using System.Windows.Forms;

namespace KalkulatorAlko
{
    public partial class Form1 : Form
    {
        private ComboBox cmbNaczynia;
        private TextBox txtWielkosc;
        private ComboBox cmbNapoje;
        private TextBox txtProcent;
        private TextBox txtIlosc;
        private Button btnOblicz;
        private Label lblWynikNapoj;
        private Label lblWynikSpirytus;

        public Form1()
        {
            InitializeComponent();
            BudujPelneGUI();
        }

        private void BudujPelneGUI()
        {
            this.Text = "Kalkulator Procentowy - Lab 02 (Wersja 5.0)";
            this.Size = new Size(440, 420);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblNaczynieLista = new Label { Text = "Typowe naczynie (opcjonalnie):", Location = new Point(20, 20), AutoSize = true };
            cmbNaczynia = new ComboBox { Location = new Point(220, 17), Width = 170, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var item in AlcoholCalculator.TypoweNaczynia.Keys) cmbNaczynia.Items.Add(item);
            cmbNaczynia.SelectedIndex = 0;
            cmbNaczynia.SelectedIndexChanged += CmbNaczynia_SelectedIndexChanged;

            Label lbl1 = new Label { Text = "Wielkość naczynia (ml):", Location = new Point(20, 60), AutoSize = true };
            txtWielkosc = new TextBox { Location = new Point(220, 57), Width = 170 };

            Label lblNapojLista = new Label { Text = "Typowy napój (opcjonalnie):", Location = new Point(20, 100), AutoSize = true };
            cmbNapoje = new ComboBox { Location = new Point(220, 97), Width = 170, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var item in AlcoholCalculator.TypoweNapoje.Keys) cmbNapoje.Items.Add(item);
            cmbNapoje.SelectedIndex = 0;
            cmbNapoje.SelectedIndexChanged += CmbNapoje_SelectedIndexChanged;

            Label lbl2 = new Label { Text = "Zawartość spirytusu (%):", Location = new Point(20, 140), AutoSize = true };
            txtProcent = new TextBox { Location = new Point(220, 137), Width = 170 };

            Label lbl3 = new Label { Text = "Ilość sztuk naczynia:", Location = new Point(20, 180), AutoSize = true };
            txtIlosc = new TextBox { Location = new Point(220, 177), Width = 170, Text = "1" };

            btnOblicz = new Button { Text = "Oblicz", Location = new Point(20, 225), Size = new Size(370, 40) };
            btnOblicz.Click += BtnOblicz_Click;

            lblWynikNapoj = new Label { Text = "Objętość napoju: 0 ml", Location = new Point(20, 285), AutoSize = true, Font = new Font(Font, FontStyle.Bold) };
            lblWynikSpirytus = new Label { Text = "Objętość czystego spirytusu: 0 ml", Location = new Point(20, 315), AutoSize = true, Font = new Font(Font, FontStyle.Bold) };

            this.Controls.AddRange(new Control[] {
                lblNaczynieLista, cmbNaczynia, lbl1, txtWielkosc,
                lblNapojLista, cmbNapoje, lbl2, txtProcent,
                lbl3, txtIlosc, btnOblicz, lblWynikNapoj, lblWynikSpirytus
            });
        }

        private void CmbNaczynia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wybrane = cmbNaczynia.SelectedItem.ToString();
            if (AlcoholCalculator.TypoweNaczynia.TryGetValue(wybrane, out double pojemnosc) && pojemnosc > 0)
                txtWielkosc.Text = pojemnosc.ToString();
        }

        private void CmbNapoje_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wybrany = cmbNapoje.SelectedItem.ToString();
            if (AlcoholCalculator.TypoweNapoje.TryGetValue(wybrany, out double procent) && procent > 0)
                txtProcent.Text = procent.ToString();
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
                MessageBox.Show("Podaj poprawne liczby! Szczegóły: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
