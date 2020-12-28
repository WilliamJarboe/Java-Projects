using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChipOptimizer
{



    public partial class Form1 : Form
    {


        List<chip> db = new List<chip>();
        List<chip> searchresults = new List<chip>();
        int page = 0;

        List<chip> pageof10 = new List<chip>();
        public class chip
        {
            public string name = "";
            public int rank = 0;
            public bool stat2exists = false;
            public bool stat3exists = false;
            public bool stat4exists = false;
            public string stat1type = "";
            public string stat2type = "";
            public string stat3type = "";
            public string stat4type = "";
            public double stat1val = 0.0;
            public double stat2val = 0.0;
            public double stat3val = 0.0;
            public double stat4val = 0.0;
            public bool compensatedexists = false;
            public string compensatedtype = "";
            public double compensatedval = 0.0;
            public string fullDefinition()
            {
                string defin = "";
                defin += "[" + name + " " + rank + "]\n" + stat1val + " " + stat1type;
                if(stat2exists)
                {
                    defin += "\n" + stat2val + " " + stat2type;
                }
                if (stat3exists)
                {
                    defin += "\n" + stat3val + " " + stat3type;
                }
                if (stat4exists)
                {
                    defin += "\n" + stat4val + " " + stat4type;
                }
                if (compensatedexists)
                {
                    defin += "\n" + compensatedval + " " + compensatedtype;
                }
                return defin;
            }
        }
        public class chipset
        {
            public List<chip> chipsInSet = new List<chip>();
            public double bonus = 0;
            public double critChance = 0;
            public void calculatePower(double defaultCritChance, double defaultCritDamage, string Element, bool useAlien, bool useDestroyer, bool useEllydium, bool onlyThermal)
            {
                double generalDmg = 0;
                double alienDmg = 0;
                double thermalDmg = 0;
                double emDmg = 0;
                double kineticDmg = 0;
                double dessieDmg = 0;
                double fireRate = 0;
                double critDamage = 0;
                double ellydiumDmg = 0;
                double legendaryHullResistNegation = 0;

                #region stat1
                for (int i = 0; i < chipsInSet.Count; i++)
                {
                    string stat1type = chipsInSet[i].stat1type;
                    double stat1val = chipsInSet[i].stat1val;
                    if (stat1type == "Damage")
                    {
                        generalDmg += stat1val;
                    }
                    else if (stat1type == "EM")
                    {
                        emDmg += stat1val;
                    }
                    else if (stat1type == "Thermal")
                    {
                        thermalDmg += stat1val;
                    }
                    else if (stat1type == "Kinetic")
                    {
                        kineticDmg += stat1val;
                    }
                    else if (stat1type == "Alien")
                    {
                        alienDmg += stat1val;
                    }
                    else if (stat1type == "Destroyer")
                    {
                        dessieDmg += stat1val;
                    }
                    else if (stat1type == "Ellydium")
                    {
                        ellydiumDmg += stat1val;
                    }
                    else if (stat1type == "Hull Resistance Debuff on Crit (Legendary)")
                    {
                        legendaryHullResistNegation += stat1val;
                    }
                    else if (stat1type == "Fire Rate")
                    {
                        fireRate += stat1val;
                    }
                    else if (stat1type == "Critical Chance")
                    {
                        critChance += stat1val;
                    }
                    else if (stat1type == "Critical Damage")
                    {
                        critDamage += stat1val;
                    }
                    #endregion
                    /**
                    Damage
                    Fire Rate
                    Thermal
                    Kinetic
                    EM
                    Alien
                    Destroyer
                    Hull Resistance Debuff on Crit(Legendary)
                    **/
                    #region stat2
                    if (chipsInSet[i].stat2exists)
                    {
                        string stat2type = chipsInSet[i].stat2type;
                        double stat2val = chipsInSet[i].stat2val;
                        if (stat2type == "Damage")
                        {
                            generalDmg += stat2val;
                        }
                        else if (stat2type == "EM")
                        {
                            emDmg += stat2val;
                        }
                        else if (stat2type == "Thermal")
                        {
                            thermalDmg += stat2val;
                        }
                        else if (stat2type == "Kinetic")
                        {
                            kineticDmg += stat2val;
                        }
                        else if (stat2type == "Alien")
                        {
                            alienDmg += stat2val;
                        }
                        else if (stat2type == "Destroyer")
                        {
                            dessieDmg += stat2val;
                        }
                        else if (stat2type == "Ellydium")
                        {
                            ellydiumDmg += stat2val;
                        }
                        else if (stat2type == "Hull Resistance Debuff on Crit(Legendary)")
                        {
                            legendaryHullResistNegation += stat1val;
                        }
                        else if (stat2type == "Fire Rate")
                        {
                            fireRate += stat2val;
                        }
                        else if (stat2type == "Critical Chance")
                        {
                            critChance += stat2val;
                        }
                        else if (stat2type == "Critical Damage")
                        {
                            critDamage += stat2val;
                        }
                    }
                    #endregion
                    #region stat3
                    if (chipsInSet[i].stat3exists)
                    {
                        string stat3type = chipsInSet[i].stat3type;
                        double stat3val = chipsInSet[i].stat3val;
                        if (stat3type == "Damage")
                        {
                            generalDmg += stat3val;
                        }
                        else if (stat3type == "EM")
                        {
                            emDmg += stat3val;
                        }
                        else if (stat3type == "Thermal")
                        {
                            thermalDmg += stat3val;
                        }
                        else if (stat3type == "Kinetic")
                        {
                            kineticDmg += stat3val;
                        }
                        else if (stat3type == "Alien")
                        {
                            alienDmg += stat3val;
                        }
                        else if (stat3type == "Destroyer")
                        {
                            dessieDmg += stat3val;
                        }
                        else if (stat3type == "Ellydium")
                        {
                            ellydiumDmg += stat3val;
                        }
                        else if (stat3type == "Hull Resistance Debuff on Crit(Legendary)")
                        {
                            legendaryHullResistNegation += stat3val;
                        }
                        else if (stat3type == "Fire Rate")
                        {
                            fireRate += stat3val;
                        }
                        else if (stat3type == "Critical Chance")
                        {
                            critChance += stat3val;
                        }
                        else if (stat3type == "Critical Damage")
                        {
                            critDamage += stat3val;
                        }
                    }
                    #endregion
                    #region stat4
                    if (chipsInSet[i].stat4exists)
                    {
                        string stat4type = chipsInSet[i].stat4type;
                        double stat4val = chipsInSet[i].stat4val;
                        if (stat4type == "Damage")
                        {
                            generalDmg += stat4val;
                        }
                        else if (stat4type == "EM")
                        {
                            emDmg += stat4val;
                        }
                        else if (stat4type == "Thermal")
                        {
                            thermalDmg += stat4val;
                        }
                        else if (stat4type == "Kinetic")
                        {
                            kineticDmg += stat4val;
                        }
                        else if (stat4type == "Alien")
                        {
                            alienDmg += stat4val;
                        }
                        else if (stat4type == "Destroyer")
                        {
                            dessieDmg += stat4val;
                        }
                        else if (stat4type == "Ellydium")
                        {
                            ellydiumDmg += stat4val;
                        }
                        else if (stat4type == "Hull Resistance Debuff on Crit(Legendary)")
                        {
                            legendaryHullResistNegation += stat4val;
                        }
                        else if (stat4type == "Fire Rate")
                        {
                            fireRate += stat4val;
                        }
                        else if (stat4type == "Critical Chance")
                        {
                            critChance += stat4val;
                        }
                        else if (stat4type == "Critical Damage")
                        {
                            critDamage += stat4val;
                        }
                    }
                    #endregion
                    #region statCompensated
                    if (chipsInSet[i].compensatedexists)
                    {
                        string compensatedtype = chipsInSet[i].compensatedtype;
                        double compensatedval = chipsInSet[i].compensatedval;
                        if (compensatedtype == "Damage")
                        {
                            generalDmg += compensatedval;
                        }
                        else if (compensatedtype == "EM")
                        {
                            emDmg += compensatedval;
                        }
                        else if (compensatedtype == "Thermal")
                        {
                            thermalDmg += compensatedval;
                        }
                        else if (compensatedtype == "Kinetic")
                        {
                            kineticDmg += compensatedval;
                        }
                        else if (compensatedtype == "Alien")
                        {
                            alienDmg += compensatedval;
                        }
                        else if (compensatedtype == "Destroyer")
                        {
                            dessieDmg += compensatedval;
                        }
                        else if (compensatedtype == "Ellydium")
                        {
                            ellydiumDmg += compensatedval;
                        }
                        else if (compensatedtype == "Fire Rate")
                        {
                            fireRate += compensatedval;
                        }
                        else if (compensatedtype == "Critical Chance")
                        {
                            critChance += compensatedval;
                        }
                        else if (compensatedtype == "Critical Damage")
                        {
                            critDamage += compensatedval;
                        }
                    }
                }
                #endregion

                critChance += defaultCritChance;
                critDamage += defaultCritDamage;

                generalDmg *= 0.01;
                alienDmg *= 0.01;
                thermalDmg *= 0.01;
                emDmg *= 0.01;
                kineticDmg *= 0.01;
                dessieDmg *= 0.01;
                fireRate *= 0.01;
                critChance *= 0.01;
                critDamage *= 0.01;

                //prevent a negative crit chance from impacting power.
                if (critChance > 1)
                {
                    critChance = 1;
                }
                else if(critChance<=0)
                {
                    critChance = 0;
                }
                critDamage *= critChance;

                generalDmg += 1;
                alienDmg += 1;
                dessieDmg += 1;
                fireRate += 1;
                critDamage += 1;
                double elementalDamage = 0;
                if (Element == "Thermal")
                {
                    elementalDamage = thermalDmg;
                }
                else if (Element == "Kinetic")
                {
                    elementalDamage = kineticDmg;
                }
                else if (Element == "EM")
                {
                    elementalDamage = emDmg;
                }
                else if (Element == "Use None")
                {
                    elementalDamage = 0;
                }
                else if(Element == "Use All")
                {
                    elementalDamage = thermalDmg + kineticDmg + emDmg;
                }

                if (legendaryHullResistNegation != 0)
                {

                    legendaryHullResistNegation *= 0.01;
                    legendaryHullResistNegation *= 3;
                    //legendaryHullResistNegation *= critChance;
                    legendaryHullResistNegation += 1;
                }
                else
                {
                    legendaryHullResistNegation = 1;
                }
                if(!useAlien)
                {
                    alienDmg = 1;
                }
                if(!useEllydium)
                {
                    //ellyDmg = 1;
                }
                if(!useDestroyer)
                {
                    dessieDmg = 1;
                }
                if(!useEllydium)
                {
                    ellydiumDmg = 1;
                }
                //the equation is effective damage=(damage + type damage)(rate of fire)[(1-critical chance)+critical chance(critical damage)](damage to alien)(damage to destroyer)
                bonus = (generalDmg + elementalDamage) * fireRate * legendaryHullResistNegation * critDamage * ellydiumDmg * alienDmg * dessieDmg;



                if (onlyThermal)
                {
                    bonus = 1+thermalDmg;
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
        }
        private void buff2Exists_CheckedChanged(object sender, EventArgs e)
        {
            buff2Type.Enabled = buff2Exists.Checked;
            buff2Value.Enabled = buff2Exists.Checked;
            if (!buff2Exists.Checked)
            {
                buff3Exists.Checked = false;
                buff3Exists.Enabled = false;
            }
            else
            {
                buff3Exists.Enabled = true;
            }
        }

        private void buff3Exists_CheckedChanged(object sender, EventArgs e)
        {
            buff3Type.Enabled = buff3Exists.Checked;
            buff3Value.Enabled = buff3Exists.Checked;
            if (!buff3Exists.Checked)
            {
                buff4Exists.Checked = false;
                buff4Exists.Enabled = false;
            }
            else
            {
                buff4Exists.Enabled = true;
            }
        }

        private void buff4Exists_CheckedChanged(object sender, EventArgs e)
        {
            buff4Type.Enabled = buff4Exists.Checked;
            buff4Value.Enabled = buff4Exists.Checked;
        }

        bool allRequirementsMetForSubmission()
        {
            if (txtName.Text != "")
            {
                if (buff1Type.Text != "")
                {

                    if (buff1Value.Text != "")
                    {
                        try
                        {
                            double.Parse(buff1Value.Text);
                            if (buff2Exists.Checked)
                            {
                                if (buff2Type.Text != "")
                                {
                                    if (buff2Value.Text != "")
                                    {
                                        try
                                        {
                                            double.Parse(buff2Value.Text);
                                            if (buff3Exists.Checked)
                                            {
                                                if (buff3Type.Text != "")
                                                {
                                                    if (buff3Value.Text != "")
                                                    {
                                                        try
                                                        {
                                                            double.Parse(buff3Value.Text);
                                                            if (buff4Exists.Checked)
                                                            {
                                                                if (buff4Type.Text != "")
                                                                {
                                                                    if (buff4Value.Text != "")
                                                                    {
                                                                        try
                                                                        {
                                                                            double.Parse(buff4Value.Text);

                                                                            return compensatedOrderly();
                                                                        }
                                                                        catch (Exception e)
                                                                        {
                                                                            //Buff 4 Value not number
                                                                            lblchipaddedconfirmation.Visible = true;
                                                                            lblchipaddedconfirmation.ForeColor = Color.Purple;
                                                                            lblchipaddedconfirmation.Text = "Value for buff 4 '" + buff4Value.Text + "' isn't a number, but should be.";
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Buff 4 no value
                                                                        lblchipaddedconfirmation.Visible = true;
                                                                        lblchipaddedconfirmation.ForeColor = Color.DarkOrange;
                                                                        lblchipaddedconfirmation.Text = "Effect '" + buff4Type.Text + "' must have a value associated with it.";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //Buff 4 needs to exist
                                                                    lblchipaddedconfirmation.Visible = true;
                                                                    lblchipaddedconfirmation.ForeColor = Color.DarkGoldenrod;
                                                                    lblchipaddedconfirmation.Text = "Buff 4 is checked as existent, but has no data.";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                return compensatedOrderly();
                                                            }
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            //Buff 3 value not number
                                                            lblchipaddedconfirmation.Visible = true;
                                                            lblchipaddedconfirmation.ForeColor = Color.Purple;
                                                            lblchipaddedconfirmation.Text = "Value for buff 3 '" + buff3Value.Text + "' isn't a number, but should be.";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Buff 3 no value
                                                        lblchipaddedconfirmation.Visible = true;
                                                        lblchipaddedconfirmation.ForeColor = Color.DarkOrange;
                                                        lblchipaddedconfirmation.Text = "Effect '" + buff3Type.Text + "' must have a value associated with it.";
                                                    }
                                                }
                                                else
                                                {
                                                    //Buff 3 needs to exist
                                                    lblchipaddedconfirmation.Visible = true;
                                                    lblchipaddedconfirmation.ForeColor = Color.DarkGoldenrod;
                                                    lblchipaddedconfirmation.Text = "Buff 3 is checked as existent, but has no data.";
                                                }
                                            }
                                            else
                                            {
                                                return compensatedOrderly();
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            //Buff 2 value not number
                                            lblchipaddedconfirmation.Visible = true;
                                            lblchipaddedconfirmation.ForeColor = Color.Purple;
                                            lblchipaddedconfirmation.Text = "Value for buff 2 '" + buff2Value.Text + "' isn't a number, but should be.";
                                        }
                                    }
                                    else
                                    {
                                        //Buff 2 no value
                                        lblchipaddedconfirmation.Visible = true;
                                        lblchipaddedconfirmation.ForeColor = Color.DarkOrange;
                                        lblchipaddedconfirmation.Text = "Effect '" + buff2Type.Text + "' must have a value associated with it.";
                                    }
                                }
                                else
                                {
                                    //Buff 2 needs to exist
                                    lblchipaddedconfirmation.Visible = true;
                                    lblchipaddedconfirmation.ForeColor = Color.DarkGoldenrod;
                                    lblchipaddedconfirmation.Text = "Buff 2 is checked as existent, but has no data.";
                                }
                            }
                            else
                            {
                                return compensatedOrderly();
                            }
                        }
                        catch (Exception E)
                        {
                            //Buff 1 value not number
                            lblchipaddedconfirmation.Visible = true;
                            lblchipaddedconfirmation.ForeColor = Color.Purple;
                            lblchipaddedconfirmation.Text = "Value for buff 1 '" + buff1Value.Text + "' isn't a number, but should be.";

                        }
                    }
                    else
                    {
                        //Buff 1 no value
                        lblchipaddedconfirmation.Visible = true;
                        lblchipaddedconfirmation.ForeColor = Color.DarkOrange;
                        lblchipaddedconfirmation.Text = "Effect '" + buff1Type.Text + "' must have a value associated with it.";
                    }
                }
                else
                {
                    lblchipaddedconfirmation.Visible = true;
                    lblchipaddedconfirmation.ForeColor = Color.DarkOrange;
                    lblchipaddedconfirmation.Text = "Surely '" + txtName.Text + "' must have at least 1 effect...";
                }
            }
            else
            {
                lblchipaddedconfirmation.Visible = true;
                lblchipaddedconfirmation.ForeColor = Color.Red;
                lblchipaddedconfirmation.Text = "Your chip needs to be named!";

            }
            return false;
        }

        private bool compensatedOrderly()
        {
            if (compensatedExists.Checked)
            {
                if (compensatedType.Text != "")
                {
                    if (compensatedValue.Text != "")
                    {
                        try
                        {
                            double.Parse(compensatedValue.Text);
                            return true;
                        }
                        catch (Exception e)
                        {
                            //value needs to be a number

                            lblchipaddedconfirmation.Visible = true;
                            lblchipaddedconfirmation.ForeColor = Color.Purple;
                            lblchipaddedconfirmation.Text = "Value for compensated statistic '" + compensatedValue.Text + "' isn't a number, but should be.";
                            return false;
                        }
                    }
                    else
                    {
                        //value should exist
                        lblchipaddedconfirmation.Visible = true;
                        lblchipaddedconfirmation.ForeColor = Color.DarkOrange;
                        lblchipaddedconfirmation.Text = "Effect '" + compensatedType.Text + "' must have a value associated with it.";
                        return false;
                    }
                }
                else
                {
                    //Debuff should exist
                    lblchipaddedconfirmation.Visible = true;
                    lblchipaddedconfirmation.ForeColor = Color.DarkGoldenrod;
                    lblchipaddedconfirmation.Text = "Compensated statistic is checked as existent, but has no data.";
                    return false;
                }
            }
            return true;
        }

        private void btnAddChip_Click(object sender, EventArgs e)
        {

            if (allRequirementsMetForSubmission())
            {
                lblchipaddedconfirmation.Visible = true;
                using (StreamWriter sw = File.AppendText("./" + txtDir.Text))
                {
                    sw.WriteLine("ChipName: " + txtName.Text);
                    sw.WriteLine("Rank: " + txtacRank.Text);
                    sw.WriteLine("Buff1: " + buff1Type.Text);
                    sw.WriteLine("Buff1Value: " + buff1Value.Text);
                    if (buff2Exists.Checked)
                    {
                        sw.WriteLine("Buff2: " + buff2Type.Text);
                        sw.WriteLine("Buff2Value: " + buff2Value.Text);
                    }
                    if (buff3Exists.Checked)
                    {
                        sw.WriteLine("Buff3: " + buff3Type.Text);
                        sw.WriteLine("Buff3Value: " + buff3Value.Text);
                    }
                    if (buff4Exists.Checked)
                    {
                        sw.WriteLine("Buff4: " + buff4Type.Text);
                        sw.WriteLine("Buff4Value: " + buff4Value.Text);
                    }
                    if (compensatedExists.Checked)
                    {
                        sw.WriteLine("CompStat: " + compensatedType.Text);
                        sw.WriteLine("CompValue: " + compensatedValue.Text);
                    }
                }
                lblchipaddedconfirmation.ForeColor = Color.Green;
                lblchipaddedconfirmation.Text = txtName.Text + " has been added!";

                txtName.Text = "";
                buff1Type.Text = "";
                buff1Value.Text = "";
                buff2Type.Text = "";
                buff2Value.Text = "";
                buff2Exists.Checked = false;
                buff3Type.Text = "";
                buff3Value.Text = "";
                buff3Exists.Checked = false;
                buff4Type.Text = "";
                buff4Value.Text = "";
                buff4Exists.Checked = false;
                compensatedType.Text = "";
                compensatedValue.Text = "";
                compensatedExists.Checked = false;
                txtacRank.Text = "17";
                //h
                button1_Click(this, e);
                int i = 0;
                foreach (chip c in db)
                {
                    if (c.rank <= ShipRank.Value)
                    {
                        i++;
                    }
                }
                if (i <= 5)
                {
                    numChipSlots.Maximum = i;
                    numChipSlots.Value = i;
                }
                else
                {
                    numChipSlots.Maximum = 5;
                    numChipSlots.Value = 5;
                }
            }
        }

        //This function reads in all of the seed chips in the listed database text file and puts them into the application.
        private void button1_Click(object sender, EventArgs e)
        {

            db.Clear();
            if (File.Exists("./" + txtDir.Text))
            {
                try
                {
                    using (var fileStream = File.OpenRead(txtDir.Text))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
                    {

                        lblChipCount.Text = "Text file found";
                        String line;
                        line = streamReader.ReadLine();
                        do
                        {
                            chip thisChip = new chip();
                            thisChip.name = line.Substring(10);
                            line = streamReader.ReadLine();
                            thisChip.rank = int.Parse(line.Substring(6));
                            line = streamReader.ReadLine();
                            thisChip.stat1type = line.Substring(7);
                            line = streamReader.ReadLine();
                            thisChip.stat1val = double.Parse(line.Substring(12));
                            if ((line = streamReader.ReadLine()) != null && line.Substring(0, 9) != "ChipName:" && line.Substring(0, 9) != "CompStat:")
                            {
                                thisChip.stat2exists = true;
                                thisChip.stat2type = line.Substring(7);
                                line = streamReader.ReadLine();
                                thisChip.stat2val = double.Parse(line.Substring(12));
                                if ((line = streamReader.ReadLine()) != null && line.Substring(0, 9) != "ChipName:" && line.Substring(0, 9) != "CompStat:")
                                {
                                    thisChip.stat3exists = true;
                                    thisChip.stat3type = line.Substring(7);
                                    line = streamReader.ReadLine();
                                    thisChip.stat3val = double.Parse(line.Substring(12));
                                    if ((line = streamReader.ReadLine()) != null && line.Substring(0, 9) != "ChipName:" && line.Substring(0, 9) != "CompStat:")
                                    {
                                        thisChip.stat4exists = true;
                                        thisChip.stat4type = line.Substring(7);
                                        line = streamReader.ReadLine();
                                        thisChip.stat4val = double.Parse(line.Substring(12));

                                    }
                                }
                            }

                            if (line != null && (line.Substring(0, 9) != "ChipName:" && ((line != null && line.Substring(0, 9) == "CompStat:") || ((line = streamReader.ReadLine()) != null && line.Substring(0, 9) == "CompStat:"))))
                            {
                                thisChip.compensatedexists = true;
                                thisChip.compensatedtype = line.Substring(10);
                                line = streamReader.ReadLine();
                                thisChip.compensatedval = double.Parse(line.Substring(11));
                                line = streamReader.ReadLine();
                            }
                            db.Add(thisChip);
                            //line = streamReader.ReadLine();
                        } while (line != null);
                        
                        lblChipCount.Visible = true;
                        lblChipCount.ForeColor = Color.Green;
                        lblChipCount.Text = "Successfully synched with collection " + txtDir.Text + " and read in " + db.Count + " seed chips.";
                        btnAddChip.Text = "Add Chip Described Above (to './" + txtDir.Text + "')";
                        if(db.Count>=40)
                        {
                            programstatus.Visible = true;
                            programstatus.ForeColor = Color.DarkRed;
                            programstatus.Text = "Warning: 40+ seed chips... make a new file.";
                        }
                        else
                        {
                            programstatus.Visible = false;
                        }
                        //btnAddChip.Enabled = true;
                        //txtName.Enabled = true;
                        //buff1Type.Enabled = true;
                        //buff1Value.Enabled = true;
                        //buff2Exists.Enabled = true;
                        //txtacRank.Enabled = true;
                        //compensatedExists.Enabled = true;
                        //useDestroyer.Enabled = true;
                        //useAlien.Enabled = true;
                        //useEllydium.Enabled = true;
                        //useThermalExclusive.Enabled = true;
                        //innateCritChance.Enabled = true;
                        //innateCritDamage.Enabled = true;
                        //btnCalcBest.Enabled = true;
                        //gunElement.Enabled = true;
                        //numChipSlots.Enabled = true;
                        //ShipRank.Enabled = true;
                        enableSystem();
                        SearchBar_TextChanged(this, e);
                    }
                }
                catch(Exception h)
                {
                    lblChipCount.ForeColor = Color.DarkRed;
                    lblChipCount.Text = "Something is wrong with the file.";
                }
            }
            else
            {
                lblChipCount.Visible = true;

                lblChipCount.ForeColor = Color.DarkGoldenrod;
                lblChipCount.Text = "Add a chip to create this non-preexisting collection file './" + txtDir.Text + "' itself.";
                btnAddChip.Enabled = true;
                txtName.Enabled = true;
                buff1Type.Enabled = true;
                buff1Value.Enabled = true;
                buff2Exists.Enabled = true;
                txtacRank.Enabled = true;
                compensatedExists.Enabled = true;
                btnAddChip.Text = "Add Chip Described Above (to new collection './" + txtDir.Text + "')";
                useDestroyer.Enabled        = false;
                useAlien.Enabled            = false;
                useEllydium.Enabled         = false;
                useThermalExclusive.Enabled = false;
                innateCritChance.Enabled    = false;
                innateCritDamage.Enabled    = false;
                btnCalcBest.Enabled         = false;
                gunElement.Enabled          = false;
                numChipSlots.Enabled        = false;
                ShipRank.Enabled            = false;

                disableSystem();
            }
        }

        private void compensatedExists_CheckedChanged(object sender, EventArgs e)
        {
            compensatedType.Enabled = compensatedExists.Checked;
            compensatedValue.Enabled = compensatedExists.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(this, e);
        }

        private void useThermalExclusive_CheckedChanged(object sender, EventArgs e)
        {
            useEllydium.Enabled = !useThermalExclusive.Checked;
            useDestroyer.Enabled = !useThermalExclusive.Checked;
            useAlien.Enabled = !useThermalExclusive.Checked;

        }

        private void txtDir_TextChanged(object sender, EventArgs e)
        {
            disableSystem();
            //lblChipCount.Visible = true;
            //btnAddChip.Enabled = false;
            //txtName.Enabled = false;
            //buff1Type.Enabled = false;
            //buff1Value.Enabled = false;
            //buff2Exists.Enabled = false;
            //txtacRank.Enabled = false;
            //compensatedExists.Enabled = false;
            //btnAddChip.Text = "Synchronization Required";
            //useDestroyer.Enabled = false;
            //useAlien.Enabled = false;
            //useEllydium.Enabled = false;
            //useThermalExclusive.Enabled = false;
            //innateCritChance.Enabled = false;
            //innateCritDamage.Enabled = false;
            //btnCalcBest.Enabled = false;
            //gunElement.Enabled = false;
            //numChipSlots.Enabled = false;
            //ShipRank.Enabled = false;

            button1_Click(this,e);
        }

        private void useAlien_CheckedChanged(object sender, EventArgs e)
        {
            if (useAlien.Checked)
            {
                useEllydium.Checked = false;
            }
        }

        private void useEllydium_CheckedChanged(object sender, EventArgs e)
        {
            if (useEllydium.Checked)
            {
                useAlien.Checked = false;
            }
        }

        private void btnCalcBest_Click(object sender, EventArgs e)
        {

            List<chipset> allPossibleCombinations = new List<chipset>();

            List<chip> dbWithinRankRange = new List<chip>();
            foreach (chip c in db)
            {
                if (ShipRank.Value >= c.rank)
                    dbWithinRankRange.Add(c);
            }

            if (numChipSlots.Text == "5")
            {
                for (int i = 0; i < dbWithinRankRange.Count - 4; i++)
                {
                    for (int j = i + 1; j < dbWithinRankRange.Count - 3; j++)
                    {
                        for (int k = j + 1; k < dbWithinRankRange.Count - 2; k++)
                        {
                            for (int l = k + 1; l < dbWithinRankRange.Count - 1; l++)
                            {
                                for (int m = l + 1; m < dbWithinRankRange.Count; m++)
                                {
                                    chipset h = new chipset();
                                    h.chipsInSet.Add(dbWithinRankRange[i]);
                                    h.chipsInSet.Add(dbWithinRankRange[j]);
                                    h.chipsInSet.Add(dbWithinRankRange[k]);
                                    h.chipsInSet.Add(dbWithinRankRange[l]);
                                    h.chipsInSet.Add(dbWithinRankRange[m]);
                                    allPossibleCombinations.Add(h);
                                }
                            }
                        }
                    }
                }
                double topPower = -1;
                chipset bestchips = new chipset();
                for (int i = 0; i < allPossibleCombinations.Count; i++)
                {
                    allPossibleCombinations[i].calculatePower(double.Parse(innateCritChance.Text), double.Parse(innateCritDamage.Text), gunElement.Text, useAlien.Checked, useDestroyer.Checked, useEllydium.Checked, useThermalExclusive.Checked);
                    if (topPower < allPossibleCombinations[i].bonus)
                    {
                        topPower = allPossibleCombinations[i].bonus;
                        bestchips = allPossibleCombinations[i];
                    }
                }
                lblslot1.Visible = true;
                lblslot2.Visible = true;
                lblslot3.Visible = true;
                lblslot4.Visible = true;
                lblslot5.Visible = true;
                labelBonusPower.Visible = true;
                lblslot1.Text = "[" + bestchips.chipsInSet[0].name + " " + bestchips.chipsInSet[0].rank + "]";
                lblslot2.Text = "[" + bestchips.chipsInSet[1].name + " " + bestchips.chipsInSet[1].rank + "]";
                lblslot3.Text = "[" + bestchips.chipsInSet[2].name + " " + bestchips.chipsInSet[2].rank + "]";
                lblslot4.Text = "[" + bestchips.chipsInSet[3].name + " " + bestchips.chipsInSet[3].rank + "]";
                lblslot5.Text = "[" + bestchips.chipsInSet[4].name + " " + bestchips.chipsInSet[4].rank + "]";
                labelBonusPower.Text = "Damage Multiplier: " + bestchips.bonus + "x    Crit: " + bestchips.critChance * 100 + "%";
            }
            else if (numChipSlots.Text == "4")
            {
                for (int i = 0; i < dbWithinRankRange.Count - 3; i++)
                {
                    for (int j = i + 1; j < dbWithinRankRange.Count - 2; j++)
                    {
                        for (int k = j + 1; k < dbWithinRankRange.Count - 1; k++)
                        {
                            for (int l = k + 1; l < dbWithinRankRange.Count; l++)
                            {
                                chipset h = new chipset();
                                h.chipsInSet.Add(dbWithinRankRange[i]);
                                h.chipsInSet.Add(dbWithinRankRange[j]);
                                h.chipsInSet.Add(dbWithinRankRange[k]);
                                h.chipsInSet.Add(dbWithinRankRange[l]);
                                allPossibleCombinations.Add(h);

                            }
                        }
                    }
                }
                double topPower = -1;
                chipset bestchips = new chipset();
                for (int i = 0; i < allPossibleCombinations.Count; i++)
                {
                    allPossibleCombinations[i].calculatePower(double.Parse(innateCritChance.Text), double.Parse(innateCritDamage.Text), gunElement.Text, useAlien.Checked, useDestroyer.Checked, useEllydium.Checked, useThermalExclusive.Checked);
                    if (topPower < allPossibleCombinations[i].bonus)
                    {
                        topPower = allPossibleCombinations[i].bonus;
                        bestchips = allPossibleCombinations[i];
                    }
                }
                lblslot1.Visible = true;
                lblslot2.Visible = true;
                lblslot3.Visible = true;
                lblslot4.Visible = true;
                lblslot5.Visible = false;
                labelBonusPower.Visible = true;
                lblslot1.Text = "[" + bestchips.chipsInSet[0].name + " " + bestchips.chipsInSet[0].rank + "]";
                lblslot2.Text = "[" + bestchips.chipsInSet[1].name + " " + bestchips.chipsInSet[1].rank + "]";
                lblslot3.Text = "[" + bestchips.chipsInSet[2].name + " " + bestchips.chipsInSet[2].rank + "]";
                lblslot4.Text = "[" + bestchips.chipsInSet[3].name + " " + bestchips.chipsInSet[3].rank + "]";
                labelBonusPower.Text = "Damage Multiplier: " + bestchips.bonus + "x    Crit: " + bestchips.critChance * 100 + "%";
            }
            else if (numChipSlots.Text == "3")
            {
                for (int i = 0; i < dbWithinRankRange.Count - 2; i++)
                {
                    for (int j = i + 1; j < dbWithinRankRange.Count - 1; j++)
                    {
                        for (int k = j + 1; k < dbWithinRankRange.Count; k++)
                        {
                            chipset h = new chipset();
                            h.chipsInSet.Add(dbWithinRankRange[i]);
                            h.chipsInSet.Add(dbWithinRankRange[j]);
                            h.chipsInSet.Add(dbWithinRankRange[k]);
                            allPossibleCombinations.Add(h);
                        }
                    }
                }
                double topPower = 0;
                chipset bestchips = new chipset();
                for (int i = 0; i < allPossibleCombinations.Count; i++)
                {
                    allPossibleCombinations[i].calculatePower(double.Parse(innateCritChance.Text), double.Parse(innateCritDamage.Text), gunElement.Text, useAlien.Checked, useDestroyer.Checked, useEllydium.Checked, useThermalExclusive.Checked);
                    if (topPower < allPossibleCombinations[i].bonus)
                    {
                        topPower = allPossibleCombinations[i].bonus;
                        bestchips = allPossibleCombinations[i];
                    }
                }
                lblslot1.Visible = true;
                lblslot2.Visible = true;
                lblslot3.Visible = true;
                lblslot4.Visible = false;
                lblslot5.Visible = false;
                labelBonusPower.Visible = true;
                lblslot1.Text = "[" + bestchips.chipsInSet[0].name + " " + bestchips.chipsInSet[0].rank + "]";
                lblslot2.Text = "[" + bestchips.chipsInSet[1].name + " " + bestchips.chipsInSet[1].rank + "]";
                lblslot3.Text = "[" + bestchips.chipsInSet[2].name + " " + bestchips.chipsInSet[2].rank + "]";
                labelBonusPower.Text = "Damage Multiplier: " + bestchips.bonus + "x    Crit: " + bestchips.critChance * 100 + "%";
            }
            else if (numChipSlots.Text == "2")
            {
                for (int i = 0; i < dbWithinRankRange.Count - 1; i++)
                {
                    for (int j = i + 1; j < dbWithinRankRange.Count; j++)
                    {
                        chipset h = new chipset();
                        h.chipsInSet.Add(dbWithinRankRange[i]);
                        h.chipsInSet.Add(dbWithinRankRange[j]);
                        allPossibleCombinations.Add(h);
                    }
                }
                double topPower = 0;
                chipset bestchips = new chipset();
                for (int i = 0; i < allPossibleCombinations.Count; i++)
                {
                    allPossibleCombinations[i].calculatePower(double.Parse(innateCritChance.Text), double.Parse(innateCritDamage.Text), gunElement.Text, useAlien.Checked, useDestroyer.Checked, useEllydium.Checked, useThermalExclusive.Checked);
                    if (topPower < allPossibleCombinations[i].bonus)
                    {
                        topPower = allPossibleCombinations[i].bonus;
                        bestchips = allPossibleCombinations[i];
                    }
                }
                lblslot1.Visible = true;
                lblslot2.Visible = true;
                lblslot3.Visible = false;
                lblslot4.Visible = false;
                lblslot5.Visible = false;
                labelBonusPower.Visible = true;
                lblslot1.Text = "[" + bestchips.chipsInSet[0].name + " " + bestchips.chipsInSet[0].rank + "]";
                lblslot2.Text = "[" + bestchips.chipsInSet[1].name + " " + bestchips.chipsInSet[0].rank + "]";
                labelBonusPower.Text = "Damage Multiplier: " + bestchips.bonus + "x    Crit: " + bestchips.critChance * 100 + "%";
            }
            else if (numChipSlots.Text == "1")
            {
                for (int i = 0; i < dbWithinRankRange.Count; i++)
                {
                    chipset h = new chipset();
                    h.chipsInSet.Add(dbWithinRankRange[i]);
                    allPossibleCombinations.Add(h);
                }
                double topPower = 0;
                chipset bestchips = new chipset();
                for (int i = 0; i < allPossibleCombinations.Count; i++)
                {
                    allPossibleCombinations[i].calculatePower(double.Parse(innateCritChance.Text), double.Parse(innateCritDamage.Text), gunElement.Text, useAlien.Checked, useDestroyer.Checked, useEllydium.Checked, useThermalExclusive.Checked);
                    if (topPower < allPossibleCombinations[i].bonus)
                    {
                        topPower = allPossibleCombinations[i].bonus;
                        bestchips = allPossibleCombinations[i];
                    }
                }
                lblslot1.Visible = true;
                lblslot2.Visible = false;
                lblslot3.Visible = false;
                lblslot4.Visible = false;
                lblslot5.Visible = false;
                labelBonusPower.Visible = true;
                lblslot1.Text = "[" + bestchips.chipsInSet[0].name + " " + bestchips.chipsInSet[0].rank + "]";
                labelBonusPower.Text = "Damage Multiplier: " + bestchips.bonus + "x  Crit: " + bestchips.critChance * 100 + "%";
            }
        }

        private void numChipSlots_EnabledChanged(object sender, EventArgs e)
        {
            int chipsWithinRange = 0;
            foreach (chip c in db)
            {
                if (ShipRank.Value >= c.rank)
                    chipsWithinRange++;
            }

            if (chipsWithinRange>=5)
            {
                numChipSlots.Maximum = 5;
                numChipSlots.Value = 5;
            }
            else
            {
                if (numChipSlots.Value > chipsWithinRange)
                {
                    numChipSlots.Value = chipsWithinRange;
                }
                numChipSlots.Maximum = chipsWithinRange;
            }
        }

        private void ShipRank_ValueChanged(object sender, EventArgs e)
        {
            int i = 0;
            foreach(chip c in db)
            {
                if(c.rank <= ShipRank.Value)
                {
                    i++;
                }
            }
            if(i<=5)
            {
                numChipSlots.Maximum = i;
                numChipSlots.Value = i;
            }
            else
            {
                numChipSlots.Maximum = 5;
                numChipSlots.Value = 5;
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            page = 0;
            searchresults.Clear();
            pageof10.Clear();

            foreach (chip c in db)
            {
                if((c.name).Contains(SearchBar.Text))
                {
                    searchresults.Add(c);
                }
            }
            nextPage.Enabled = searchresults.Count > 10;

            refactorSearch();
            for (int i = searchresults.Count; i<=10; i++)
            {
                searchresults.Add(new chip());
            }

            for (int i = 0; i<10; i++)
            {
                pageof10.Add(searchresults[i]);
            }


        }

        private void disableSystem()
        {
            useDestroyer.Enabled        = false;
            useAlien.Enabled            = false;
            useEllydium.Enabled         = false;
            useThermalExclusive.Enabled = false;
            innateCritChance.Enabled    = false;
            innateCritDamage.Enabled    = false;
            btnCalcBest.Enabled         = false;
            gunElement.Enabled          = false;
            numChipSlots.Enabled        = false;
            ShipRank.Enabled            = false;
            SearchBar.Enabled           = false;
            lblslot1.Visible            = false;
            lblslot2.Visible            = false;
            lblslot3.Visible            = false;
            lblslot4.Visible            = false;
            lblslot5.Visible            = false;
            editresult1.Enabled         = false;
            editresult2.Enabled         = false;
            editresult3.Enabled         = false;
            editresult4.Enabled         = false;
            editresult5.Enabled         = false;
            editresult6.Enabled         = false;
            editresult7.Enabled         = false;
            editresult8.Enabled         = false;
            editresult9.Enabled         = false;
            editresult10.Enabled        = false;
            totalindb.Visible           = false;
            showingCount.Visible        = false;
            result1.Text                = "";
            result2.Text                = "";
            result3.Text                = "";
            result4.Text                = "";
            result5.Text                = "";
            result6.Text                = "";
            result7.Text                = "";
            result8.Text                = "";
            result9.Text                = "";
            result10.Text               = "";
            btnAddChip.Text             = "Add chip to new collection \""+txtDir.Text+"\"";
        }

        private void enableSystem()
        {
            btnAddChip.Enabled          = true;
            txtName.Enabled             = true;
            buff1Type.Enabled           = true;
            buff1Value.Enabled          = true;
            buff2Exists.Enabled         = true;
            txtacRank.Enabled           = true;
            compensatedExists.Enabled   = true;
            useDestroyer.Enabled        = true;
            useAlien.Enabled            = true;
            useEllydium.Enabled         = true;
            useThermalExclusive.Enabled = true;
            innateCritChance.Enabled    = true;
            innateCritDamage.Enabled    = true;
            btnCalcBest.Enabled         = true;
            gunElement.Enabled          = true;
            numChipSlots.Enabled        = true;
            ShipRank.Enabled            = true;
            SearchBar.Enabled           = true;
            lblslot1.Visible            = true;
            lblslot2.Visible            = true;
            lblslot3.Visible            = true;
            lblslot4.Visible            = true;
            lblslot5.Visible            = true;
            btnAddChip.Text             = "Add Chip";
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            
            page++;
            pageof10.Clear();
            refactorSearch();
            if(searchresults.Count>((page+1)*10))
            {
                nextPage.Enabled = true;
            }
            else
            {
                nextPage.Enabled = false;
            }
            previousPage.Enabled = true;
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            page--;
            pageof10.Clear();
            refactorSearch();
            if (page>0)
            {
                previousPage.Enabled = true;
            }
            else
            {
                previousPage.Enabled = false;
            }
            nextPage.Enabled = true;
        }

        public void refactorSearch()
        {
            for (int i = (page * 10); i < (page * 10) + 10; i++)
            {
                if (searchresults.Count > i)
                {
                    pageof10.Add(searchresults[i]);
                }
                else
                {
                    pageof10.Add(new chip());
                }
            }

            result1.Text = "[" + pageof10[0].name + " " + pageof10[0].rank + "]";
            toolTip1.SetToolTip(result1, pageof10[0].fullDefinition());
            result2.Text = "[" + pageof10[1].name + " " + pageof10[1].rank + "]";
            toolTip1.SetToolTip(result2, pageof10[1].fullDefinition());
            result3.Text = "[" + pageof10[2].name + " " + pageof10[2].rank + "]";
            toolTip1.SetToolTip(result3, pageof10[2].fullDefinition());
            result4.Text = "[" + pageof10[3].name + " " + pageof10[3].rank + "]";
            toolTip1.SetToolTip(result4, pageof10[3].fullDefinition());
            result5.Text = "[" + pageof10[4].name + " " + pageof10[4].rank + "]";
            toolTip1.SetToolTip(result5, pageof10[4].fullDefinition());
            result6.Text = "[" + pageof10[5].name + " " + pageof10[5].rank + "]";
            toolTip1.SetToolTip(result6, pageof10[5].fullDefinition());
            result7.Text = "[" + pageof10[6].name + " " + pageof10[6].rank + "]";
            toolTip1.SetToolTip(result7, pageof10[6].fullDefinition());
            result8.Text = "[" + pageof10[7].name + " " + pageof10[7].rank + "]";
            toolTip1.SetToolTip(result8, pageof10[7].fullDefinition());
            result9.Text = "[" + pageof10[8].name + " " + pageof10[8].rank + "]";
            toolTip1.SetToolTip(result9, pageof10[8].fullDefinition());
            result10.Text = "[" + pageof10[9].name + " " + pageof10[9].rank + "]";
            toolTip1.SetToolTip(result10, pageof10[9].fullDefinition());
            editresult1.Enabled = result1.Text != "[ 0]";
            editresult2.Enabled = result2.Text != "[ 0]";
            editresult3.Enabled = result3.Text != "[ 0]";
            editresult4.Enabled = result4.Text != "[ 0]";
            editresult5.Enabled = result5.Text != "[ 0]";
            editresult6.Enabled = result6.Text != "[ 0]";
            editresult7.Enabled = result7.Text != "[ 0]";
            editresult8.Enabled = result8.Text != "[ 0]";
            editresult9.Enabled = result9.Text != "[ 0]";
            editresult10.Enabled = result10.Text != "[ 0]";

            int wether = (page + 1) * 10;
            if (searchresults.Count < wether)
            {
                wether = searchresults.Count;
            }
            showingCount.Visible = true;

            totalindb.Visible = true;
            showingCount.Text = "Showing " + ((page * 10) + 1) + " - " + wether + " of " + searchresults.Count + " search results";
            totalindb.Text = "out of " + db.Count + " total chips in the collection.";
        }
    }
}