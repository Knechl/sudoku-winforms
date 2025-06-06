using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Erzeugen der DataGridView-Zeilen
            for (int i = 0; i < 9; i++)
            {
                this.dataGridView1.Rows.Add();
            }
        }
        // Globale Variablen
        int[,,] feld = new int[9, 9, 10];
        bool[,] maske = new bool[9, 9];
        Random zufallszahl = new Random(DateTime.Now.Millisecond);
        bool gamestarted = false;
        int fail = 0;

        // Trennlinien zeichnen
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Pen stift = new Pen(Brushes.Black);
            stift.Width = 2.0F;
            e.Graphics.DrawLine(stift, 0, 242, 363, 242);
            e.Graphics.DrawLine(stift, 0, 121, 363, 121);
            e.Graphics.DrawLine(stift, 121, 0, 121, 363);
            e.Graphics.DrawLine(stift, 242, 0, 242, 363);
        }

        // Spiel starten
        private void newgame_Click(object sender, EventArgs e)
        {
            gamestarted = true;

            int vorgabe = 0;
            if (leicht.Checked)
            {
                vorgabe = 34;
            }
            if (mittel.Checked)
            {
                vorgabe = 30;
            }
            if (schwer.Checked)
            {
                vorgabe = 26;
            }

            // zurücksetzen der fails
            fail = 0;
            fails.Text = "Fehler: " + fail + "/3";

            // Farben zurücksetzen
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1[i, j].Value = "";
                    dataGridView1[i, j].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                }
            }

            loeschen();
            neu();
            maske_erzeugen(vorgabe);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1[i, j].Value = "";
                    if (maske[i, j] == true)
                    {
                        dataGridView1[i, j].Value = feld[i, j, 0];
                    }
                }
            }
        }

        // Eingaben löschen
        private void redo_Click(object sender, EventArgs e)
        {
            // Nur wenn Spiel noch aktiv ist
            if (gamestarted == false)
            {
                return;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (maske[i, j] == true)
                    {
                        dataGridView1[i, j].Value = Convert.ToString(feld[i, j, 0]);
                    }
                    else
                    {
                        dataGridView1[i, j].Value = "";
                        dataGridView1[i, j].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                        dataGridView1[i, j].ReadOnly = false;
                    }
                }
            }
            // zurücksetzen der fails
            fail = 0;
            fails.Text = "Fehler: " + fail + "/3";
        }

        // Spiel lösen
        private void showresult_Click(object sender, EventArgs e)
        {
            // zurücksetzen der fails
            fail = 0;
            fails.Text = "Fehler: " + fail + "/3";

            if (gamestarted == true)
            {
                // Rufe in der Methode 'neu' den Wert aus Ebene 0 des Arrays aus und schreibt ihn
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        dataGridView1[i, j].Value = feld[i, j, 0].ToString();
                        dataGridView1[i, j].ReadOnly = true;
                    }
                }
                gamestarted = false;
            }
        }

        // Cell Value Changed [komplizierte Scheiße]
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int spalten = dataGridView1.ColumnCount;
            int zeilen = dataGridView1.RowCount;

            for (int i = 0; i < spalten; i++)
            {
                for (int j = 0; j < zeilen; j++)
                {
                    string loesung = feld[i, j, 0].ToString();
                    object cellValue = dataGridView1[i, j].Value;
                    string eingabe = cellValue != null ? cellValue.ToString() : "";

                    // Lösung richtig
                    if (loesung == eingabe)
                    {
                        dataGridView1[i, j].ReadOnly = true;
                    }

                    // Lösung falsch
                    if (loesung != "0" && eingabe != "")
                    {
                        if (loesung == eingabe)
                        {
                            if (dataGridView1[i, j].Style.BackColor == Color.Red)
                            {
                                //dataGridView1[i, j].ReadOnly = true;
                                dataGridView1[i, j].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                            }
                        }
                        else
                        {
                            // Check,dass nicht immer alle fehler gezählt werden.
                            if (dataGridView1[i, j].Style.BackColor != Color.Red)
                            {
                                dataGridView1[i, j].Style.BackColor = Color.Red;
                                fail++;
                                fails.Text = "Fehler: " + fail + "/3";
                                if (fail == 3)
                                {
                                    // Das weiterspielen blockieren
                                    for (int k = 0; k < 9; k++)
                                    {
                                        for (int l = 0; l < 9; l++)
                                        {
                                            dataGridView1[k, l].ReadOnly = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Löschen der Felder
        void loeschen()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        feld[i, j, k] = 0;
                        // Read Only auf den Feldern deaktivieren.
                        dataGridView1[i, j].ReadOnly = false;
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    maske[i, j] = false;
                }
            }
        }

        // Neue Lösung generieren
        void neu()
        {
            int summe, x, y, z;
            bool nicht_zu_ende = true;
            x = 0;
            y = 0;

            while (nicht_zu_ende)
            {
                summe = 0;
                for (int i = 1; i < 10; i++)
                {
                    summe = summe + feld[x, y, i];
                }
                if (summe == 9)
                {
                    for (z = 1; z < 10; z++)
                    {
                        feld[x, y, z] = 0;
                    }
                    zurueck(ref x, ref y);
                    feld[x, y, 0] = 0;
                }
                else
                {
                    z = zufallszahl.Next(0, 9) + 1;
                    while (feld[x, y, z] == 1)
                    {
                        z = z + 1;
                        if (z == 10)
                        {
                            z = 1;
                        }
                    }
                    feld[x, y, 0] = z;
                    feld[x, y, z] = 1;
                    if (pruef(x, y) == true)
                    {
                        vorwärts(ref x, ref y);
                    }
                    else
                    {
                        feld[x, y, 0] = 0;
                    }
                }

                // Überprüfe, ob noch ein Feld 0 ist
                nicht_zu_ende = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (feld[i, j, 0] == 0)
                        {
                            nicht_zu_ende = true;
                            break;
                        }
                    }
                    if (nicht_zu_ende)
                    {
                        break;
                    }
                }
            }
        }

        // Maske erzeugen
        void maske_erzeugen(int felder)
        {
            int k = 0;
            int x, y;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    maske[i, j] = false;
                }
            }
            while (k < felder)
            {
                x = zufallszahl.Next(0, 9);
                y = zufallszahl.Next(0, 9);

                if (maske[x, y] == false)
                {
                    maske[x, y] = true;
                    k++;
                }
            }
            // Boxen read only geben, Farbe geben
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (maske[i, j] == true)
                    {
                        dataGridView1[i, j].ReadOnly = true;
                        dataGridView1[i, j].Style.BackColor = Color.PowderBlue;
                    }
                }
            }
        }

        // Gültigkeit prüfen (Zeilenüberprüfung)
        bool pruef(int x, int y)
        {
            bool v = true;
            for (int i = 0; i < 9; i++)
            {
                if (i != x)
                {
                    if (feld[x, y, 0] == feld[i, y, 0])
                    {
                        v = false;
                    }
                }
            }
            for (int j = 0; j <= 8; j++)
            {
                if (j != y)
                {
                    if (feld[x, y, 0] == feld[x, j, 0])
                    {
                        v = false;
                    }
                }
            }
            for (int i = (x / 3) * 3; i <= (x / 3) * 3 + 2; i++)
            {
                for (int j = (y / 3) * 3; j <= (y / 3) * 3 + 2; j++)
                {
                    if (i != x && j != y)
                    {
                        if (feld[x, y, 0] == feld[i, j, 0])
                        {
                            v = false;
                        }
                    }
                }
            }
            return v;
        }

        // Vorwärts bewegen
        void vorwärts(ref int x, ref int y)
        {
            if (y == 8)
            {
                if (x < 8)
                {
                    y = 0;
                    x = x + 1;
                }
            }
            else
            {
                y = y + 1;
            }
        }

        // Zurück bewegen
        void zurueck(ref int x, ref int y)
        {
            if (y == 0)
            {
                if (x > 0)
                {
                    y = 8;
                    x = x - 1;
                }
            }
            else
            {
                y = y - 1;
            }
        }

        // Eingabe überprüfen
        bool eingabe(int x, int y)
        {
            bool v = false;
            int wert = 0;
            string feldwert = "";

            wert = Convert.ToInt32(dataGridView1[x, y].Value);
            if (wert < 1 || wert > 9)
            {
                dataGridView1[x, y].Value = " ";
                v = true;
            }

            for (int i = 0; i < 9; i++)
            {
                if (i != x)
                {
                    feldwert = Convert.ToString(dataGridView1[i, y].Value);
                    if (feldwert == "")
                    {
                        feldwert = "0";
                    }
                    if (wert == Convert.ToInt32(feldwert))
                    {
                        v = true;
                    }
                }
            }

            for (int j = 0; j < 9; j++)
            {
                if (j != y)
                {
                    feldwert = Convert.ToString(dataGridView1[x, j].Value);
                    if (feldwert == "")
                    {
                        feldwert = "0";
                    }
                    if (wert == Convert.ToInt32(feldwert))
                    {
                        v = true;
                    }
                }
            }

            for (int i = (x / 3) * 3; i < (x / 3) * 3 + 3; i++)
            {
                for (int j = (y / 3) * 3; j < (y / 3) * 3 + 3; j++)
                {
                    if (!(i == x && j == y))
                    {
                        feldwert = Convert.ToString(dataGridView1[i, j].Value);
                        if (feldwert == "")
                        {
                            feldwert = "0";
                        }
                        if (wert == Convert.ToInt32(feldwert))
                        {
                            v = true;
                        }
                    }
                }
            }
            return v;
        }

        // eigenes Sudoku lösen
        void sudokuloesen()
        {
            if (SudokuRekursivLoesen(0, 0))
            {
                // Lösung gefunden - nichts zu tun
            }
            else
            {
                MessageBox.Show("Das Sudoku konnte nicht gelöst werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Rekursiver Hilfslöser
        bool SudokuRekursivLoesen(int x, int y)
        {
            if (x == 9)
            {
                return true;
            }

            int nextX = (y == 8) ? x + 1 : x;
            int nextY = (y == 8) ? 0 : y + 1;

            if (maske[x, y] == true)
            {
                return SudokuRekursivLoesen(nextX, nextY);
            }
            for (int z = 1; z <= 9; z++)
            {
                feld[x, y, 0] = z;

                if (pruef(x, y))
                {
                    if (SudokuRekursivLoesen(nextX, nextY))
                    {
                        return true;
                    }
                }
            }
            feld[x, y, 0] = 0;
            return false;
        }

        // Ergebnis anzeigen von eigenem Sudoku
        private void resultsudoku_Click(object sender, EventArgs e)
        {
            // Einlesen Array + sagen wo man nichts bearbeiten darf
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Nur lesbar machen
                    dataGridView1[i, j].ReadOnly = true;

                    string feldwert = Convert.ToString(dataGridView1[i, j].Value);
                    if (feldwert == "")
                    {
                        feld[i, j, 0] = 0;
                        maske[i, j] = false;
                    }
                    else
                    {
                        feld[i, j, 0] = Convert.ToInt32(dataGridView1[i, j].Value);
                        maske[i, j] = true;
                    }
                }
            }

            sudokuloesen();

            // Ausgabe
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1[i, j].Value = feld[i, j, 0];
                    if (maske[i, j] == false)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        // Spiel löschen
        private void resetgame_Click(object sender, EventArgs e)
        {
            // zurücksetzen der fails
            fail = 0;
            fails.Text = "Fehler: " + fail + "/3";

            loeschen();
            // Mask leeren
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1[i, j].Value = "";
                    dataGridView1[i, j].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                }
            }
            gamestarted = false;
        }
    }
}