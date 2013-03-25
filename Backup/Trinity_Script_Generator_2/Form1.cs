namespace Trinity_Script_Generator_2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ComboBox comboBox1;
        private ComboBox comboBox10;
        private ComboBox comboBox11;
        private ComboBox comboBox12;
        private ComboBox comboBox13;
        private ComboBox comboBox14;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private ComboBox comboBox7;
        private ComboBox comboBox8;
        private ComboBox comboBox9;
        private IContainer components;
        private CORE_TYPE Core_Type;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private List<Spell> nonPhasedSpells;
        private List<Phase> phases;
        private List<SpellImmunity> spellImmunities;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox textBox1;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox2;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox28;
        private TextBox textBox29;
        private TextBox textBox3;
        private TextBox textBox30;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private ToolTip toolTip1;
        private ToolTip toolTip10;
        private ToolTip toolTip11;
        private ToolTip toolTip12;
        private ToolTip toolTip13;
        private ToolTip toolTip14;
        private ToolTip toolTip15;
        private ToolTip toolTip16;
        private ToolTip toolTip17;
        private ToolTip toolTip18;
        private ToolTip toolTip19;
        private ToolTip toolTip2;
        private ToolTip toolTip20;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip6;
        private ToolTip toolTip7;
        private ToolTip toolTip8;
        private ToolTip toolTip9;
        private int x = 1;

        public Form1()
        {
            this.InitializeComponent();
            this.phases = new List<Phase>();
            this.nonPhasedSpells = new List<Spell>();
            this.spellImmunities = new List<SpellImmunity>();
            this.toolTip1.SetToolTip(this.label1, "The name of the NPC");
            this.toolTip2.SetToolTip(this.label2, "The entry of the NPC");
            this.toolTip3.SetToolTip(this.label15, "Whether or not the npc can move");
            this.toolTip4.SetToolTip(this.label9, "The phases id");
            this.toolTip5.SetToolTip(this.label10, "The condition that must be met for this phase to activate");
            this.toolTip6.SetToolTip(this.label11, "The percent or health amount for the condition");
            this.toolTip7.SetToolTip(this.label13, "The chat message sent when this phase is activated (optional)");
            this.toolTip8.SetToolTip(this.label14, "The type of chat message sent");
            this.toolTip9.SetToolTip(this.label3, "The id of the spell");
            this.toolTip10.SetToolTip(this.label4, "The interval(s) at which the spell is casted");
            this.toolTip11.SetToolTip(this.label6, "The target of the spell");
            this.toolTip12.SetToolTip(this.label12, "The phase this spell is used in (optional). Must match an existing phase!");
            this.toolTip13.SetToolTip(this.label23, "The percent at which the npc will enrage");
            this.toolTip14.SetToolTip(this.label20, "The id of the spell");
            this.toolTip15.SetToolTip(this.label21, "The target of the spell");
            this.toolTip16.SetToolTip(this.label26, "The chat message sent when this event occurs");
            this.toolTip17.SetToolTip(this.label22, "The type of chat messenge sent");
            this.toolTip18.SetToolTip(this.label28, "Specific spell ID to make the npc immune to");
            this.toolTip19.SetToolTip(this.label29, "Spell school to make the npc immune to");
            this.toolTip20.SetToolTip(this.label8, "The core that this script will be generated for");
        }

        private void AddPhase(int id, string condition, int arguement, string text, string chatType)
        {
            Phase item = new Phase {
                Id = id,
                Condition = condition,
                Arguement = arguement,
                Text = text,
                ChatType = chatType
            };
            this.phases.Add(item);
        }

        private void AddSpellImmunity(int spellId, string school)
        {
            SpellImmunity item = new SpellImmunity {
                School = school,
                SpellId = spellId
            };
            this.spellImmunities.Add(item);
        }

        private void AddSpellNonPhased(int spellId, int castTimeLow, int castTimeHigh, string target)
        {
            Spell item = new Spell {
                SpellId = spellId,
                CastTimeLow = castTimeLow * 0x3e8
            };
            if (castTimeHigh != 0)
            {
                item.CastTimeHigh = (castTimeHigh * 0x3e8) - item.CastTimeLow;
            }
            item.Target = target;
            item.Phase = 0;
            this.nonPhasedSpells.Add(item);
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] bytes = new UTF8Encoding(true).GetBytes(value);
            fs.Write(bytes, 0, bytes.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            if (this.textBox3.Text == "")
            {
                MessageBox.Show("Spell ID cannot be empty!");
            }
            else if (this.textBox6.Text == "")
            {
                MessageBox.Show("The spell must have a cast time!");
            }
            else if (this.comboBox1.SelectedItem == null)
            {
                MessageBox.Show("The spell must have a target!");
            }
            else if (!int.TryParse(this.textBox3.Text, out result))
            {
                MessageBox.Show("Spell ID must be a number!");
            }
            else if (!int.TryParse(this.textBox6.Text, out num2))
            {
                MessageBox.Show("Cast time must be a number!");
            }
            else if ((this.textBox8.Text != "") && !int.TryParse(this.textBox8.Text, out num3))
            {
                MessageBox.Show("Cast time must be a number!");
            }
            else if ((this.textBox21.Text != "") && !int.TryParse(this.textBox21.Text, out num4))
            {
                MessageBox.Show("Phase must be a number!");
            }
            else if ((this.textBox8.Text != "") && (this.textBox6.Text == ""))
            {
                MessageBox.Show("The first cast time is empty but the second isn't!");
            }
            else
            {
                if (num3 != 0)
                {
                    if (num2 > num3)
                    {
                        MessageBox.Show("The first cast time must be lower then the second");
                        return;
                    }
                    if (num2 == num3)
                    {
                        MessageBox.Show("The first cast time cannot be the same as the second");
                        return;
                    }
                }
                if ((num4 != 0) && (this.FindPhaseById(num4) == null))
                {
                    MessageBox.Show("The phase specified doesn't exist");
                }
                else
                {
                    this.textBox4.Text = this.textBox4.Text + result.ToString() + "\r\n";
                    this.textBox5.Text = this.textBox5.Text + num2.ToString() + "\r\n";
                    if (num3 != 0)
                    {
                        this.textBox7.Text = this.textBox7.Text + num3.ToString() + "\r\n";
                    }
                    else
                    {
                        this.textBox7.Text = this.textBox7.Text + "x\r\n";
                    }
                    if (this.comboBox1.SelectedItem != null)
                    {
                        this.textBox9.Text = this.textBox9.Text + this.comboBox1.SelectedItem.ToString() + "\r\n";
                    }
                    else
                    {
                        this.textBox9.Text = this.textBox9.Text + "x\r\n";
                    }
                    if (num4 != 0)
                    {
                        this.textBox17.Text = this.textBox17.Text + num4.ToString() + "\r\n";
                    }
                    else
                    {
                        this.textBox17.Text = this.textBox17.Text + "0\r\n";
                    }
                    if (num4 != 0)
                    {
                        if (this.comboBox1.SelectedItem != null)
                        {
                            this.FindPhaseById(num4).AddSpell(result, num2, num3, this.comboBox1.SelectedItem.ToString());
                        }
                        else
                        {
                            this.FindPhaseById(num4).AddSpell(result, num2, num3, "");
                        }
                    }
                    else if (this.comboBox1.SelectedItem != null)
                    {
                        this.AddSpellNonPhased(result, num2, num3, this.comboBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        this.AddSpellNonPhased(result, num2, num3, "");
                    }
                    this.textBox3.Text = "";
                    this.textBox6.Text = "";
                    this.textBox8.Text = "";
                    this.comboBox1.SelectedItem = null;
                    this.textBox21.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (this.comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Phase condition cannot be blank!");
            }
            else if (this.textBox16.Text == "")
            {
                MessageBox.Show("The phase must have a % or timer!");
            }
            else if (!int.TryParse(this.textBox16.Text, out result))
            {
                MessageBox.Show("Timer/Percent must be a number!");
            }
            else if ((this.textBox19.Text != "") && (this.comboBox5.SelectedItem == null))
            {
                MessageBox.Show("You have a text but no chat type selected!");
            }
            else if ((this.textBox19.Text == "") && (this.comboBox5.SelectedItem != null))
            {
                MessageBox.Show("You have a chat type selected but no text!");
            }
            else
            {
                this.textBox13.Text = this.textBox13.Text + this.x.ToString() + "\r\n";
                this.textBox14.Text = this.textBox14.Text + this.comboBox3.SelectedItem.ToString() + "\r\n";
                this.textBox15.Text = this.textBox15.Text + result.ToString() + "\r\n";
                if (this.textBox19.Text != "")
                {
                    this.textBox18.Text = this.textBox18.Text + this.textBox19.Text + "\r\n";
                }
                else
                {
                    this.textBox18.Text = this.textBox18.Text + "x\r\n";
                }
                if (this.comboBox5.SelectedItem != null)
                {
                    this.textBox20.Text = this.textBox20.Text + this.comboBox5.SelectedItem.ToString() + "\r\n";
                }
                else
                {
                    this.textBox20.Text = this.textBox20.Text + "x\r\n";
                }
                if ((this.comboBox3.SelectedItem != null) && (this.comboBox5.SelectedItem != null))
                {
                    this.AddPhase(this.x, this.comboBox3.SelectedItem.ToString(), result, this.textBox19.Text, this.comboBox5.SelectedItem.ToString());
                }
                else
                {
                    this.AddPhase(this.x, "", result, this.textBox19.Text, "");
                }
                this.comboBox3.SelectedItem = null;
                this.textBox16.Text = "";
                this.textBox19.Text = "";
                this.comboBox5.SelectedItem = null;
                this.x++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            string str = "spell";
            string str2 = "phase";
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Npc name cannot be empty!");
            }
            else if (this.textBox2.Text == "")
            {
                MessageBox.Show("Npc entry cannot be empty!");
            }
            else if (this.comboBox2.SelectedItem == null)
            {
                MessageBox.Show("You must select a core type!");
            }
            else
            {
                string str3 = this.comboBox2.SelectedItem.ToString().ToLower();
                if (str3 != null)
                {
                    if (!(str3 == "trinity"))
                    {
                        if (str3 == "mangos")
                        {
                            this.Core_Type = CORE_TYPE.MANGOS;
                        }
                    }
                    else
                    {
                        this.Core_Type = CORE_TYPE.TRINITY;
                    }
                }
                if (((this.textBox22.Text != "") || (this.textBox27.Text != "")) && (this.textBox26.Text == ""))
                {
                    MessageBox.Show("You must have an enrage percent specified!");
                }
                else if ((this.textBox22.Text != "") && (this.comboBox4.SelectedItem == null))
                {
                    MessageBox.Show("You have an enrage spell id specified but no target!");
                }
                else if ((this.comboBox4.SelectedItem != null) && (this.textBox22.Text == ""))
                {
                    MessageBox.Show("You have an enrage target specified but no spell id!");
                }
                else if ((this.textBox27.Text != "") && (this.comboBox10.SelectedItem == null))
                {
                    MessageBox.Show("You have an enrage text specified but no chat type");
                }
                else if ((this.comboBox10.SelectedItem != null) && (this.textBox27.Text == ""))
                {
                    MessageBox.Show("You have an enrage chat type specified but no text!");
                }
                else if ((this.textBox23.Text != "") && (this.comboBox7.SelectedItem == null))
                {
                    MessageBox.Show("You have an aggro spell id specified but no target!");
                }
                else if ((this.comboBox7.SelectedItem != null) && (this.textBox23.Text == ""))
                {
                    MessageBox.Show("You have an aggro spell id target specified but no spell id!");
                }
                else if ((this.textBox28.Text != "") && (this.comboBox11.SelectedItem == null))
                {
                    MessageBox.Show("You have aggro text specified but no chat type");
                }
                else if ((this.comboBox11.SelectedItem != null) && (this.textBox28.Text == ""))
                {
                    MessageBox.Show("You have an aggro chat type specified but no text!");
                }
                else if ((this.textBox24.Text != "") && (this.comboBox8.SelectedItem == null))
                {
                    MessageBox.Show("You have a killed player spell id specified but no target!");
                }
                else if ((this.comboBox8.SelectedItem != null) && (this.textBox24.Text == ""))
                {
                    MessageBox.Show("You have a killed player spell id target specified but no spell id!");
                }
                else if ((this.textBox29.Text != "") && (this.comboBox12.SelectedItem == null))
                {
                    MessageBox.Show("You have killed player text specified but no chat type");
                }
                else if ((this.comboBox12.SelectedItem != null) && (this.textBox29.Text == ""))
                {
                    MessageBox.Show("You have a killed player chat type specified but no text!");
                }
                else if ((this.textBox25.Text != "") && (this.comboBox9.SelectedItem == null))
                {
                    MessageBox.Show("You have a death spell id specified but no target!");
                }
                else if ((this.comboBox9.SelectedItem != null) && (this.textBox25.Text == ""))
                {
                    MessageBox.Show("You have a death spell id target specified but no spell id!");
                }
                else if ((this.textBox30.Text != "") && (this.comboBox13.SelectedItem == null))
                {
                    MessageBox.Show("You have death text specified but no chat type");
                }
                else if ((this.comboBox13.SelectedItem != null) && (this.textBox30.Text == ""))
                {
                    MessageBox.Show("You have a death chat type specified but no text!");
                }
                else if ((this.textBox2.Text != "") && !int.TryParse(this.textBox2.Text, out num6))
                {
                    MessageBox.Show("Npc entry must be a number!");
                }
                else if ((this.textBox26.Text != "") && !int.TryParse(this.textBox26.Text, out result))
                {
                    MessageBox.Show("Enrage percent must be a number!");
                }
                else if ((this.textBox22.Text != "") && !int.TryParse(this.textBox22.Text, out num2))
                {
                    MessageBox.Show("Enrage spell id must be a number!");
                }
                else if ((this.textBox23.Text != "") && !int.TryParse(this.textBox23.Text, out num3))
                {
                    MessageBox.Show("Aggro spell id must be a number!");
                }
                else if ((this.textBox24.Text != "") && !int.TryParse(this.textBox24.Text, out num4))
                {
                    MessageBox.Show("Killed player spell id must be a number!");
                }
                else if ((this.textBox25.Text != "") && !int.TryParse(this.textBox25.Text, out num5))
                {
                    MessageBox.Show("Death spell id must be a number!");
                }
                else
                {
                    if ((this.nonPhasedSpells.Count == 0) && (this.phases.Count == 0))
                    {
                        switch (MessageBox.Show("Warning: You are about to create a script with no spells or phases!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                        {
                            case DialogResult.Cancel:
                                return;
                        }
                    }
                    using (FileStream stream = File.Create(Application.StartupPath + @"\" + this.textBox1.Text + ".cpp"))
                    {
                        string[] strArray;
                        string str4;
                        List<Spell>.Enumerator enumerator;
                        string str6;
                        string str7;
                        string str8;
                        string str9;
                        string str10;
                        string str11;
                        if (this.Core_Type != CORE_TYPE.TRINITY)
                        {
                            goto Label_1F69;
                        }
                        AddText(stream, "// Script Generated: " + DateTime.Now);
                        AddText(stream, "\r\n// Run this query on your world database");
                        AddText(stream, "\r\n// UPDATE `creature_template` SET ScriptName='npc_" + this.textBox1.Text + "' WHERE `entry`=" + num6.ToString() + ";");
                        AddText(stream, "\r\n#include \"ScriptedPch.h\"\r\n");
                        AddText(stream, "\r\n\nstruct " + this.textBox1.Text + "AI : public ScriptedAI");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n\t" + this.textBox1.Text + "AI(Creature *c) : ScriptedAI(c)");
                        AddText(stream, "\r\n\t{");
                        if (((this.comboBox4.SelectedItem != null) && ((str4 = this.comboBox6.SelectedItem.ToString().ToLower()) != null)) && (!(str4 == "true") && (str4 == "false")))
                        {
                            AddText(stream, "\r\n\t\tSetCombatMovement(false);");
                        }
                        AddText(stream, "\r\n\t}\r\n");
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            using (enumerator = this.nonPhasedSpells.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    Spell current = enumerator.Current;
                                    num7++;
                                    str = str + num7.ToString();
                                    AddText(stream, "\r\n\tuint32 " + str + "_Timer;");
                                    str = "spell";
                                }
                            }
                        }
                        num7 = 0;
                        num8 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase in this.phases)
                            {
                                num8++;
                                num7 = 0;
                                if (phase.Spells.Count > 0)
                                {
                                    using (List<Spell>.Enumerator enumerator3 = phase.Spells.GetEnumerator())
                                    {
                                        while (enumerator3.MoveNext())
                                        {
                                            Spell local2 = enumerator3.Current;
                                            num7++;
                                            str = str + num7.ToString();
                                            str2 = str2 + num8.ToString();
                                            AddText(stream, "\r\n\tuint32 " + str + "_" + str2 + "_Timer;");
                                            str = "spell";
                                            str2 = "phase";
                                        }
                                        continue;
                                    }
                                }
                            }
                        }
                        num7 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase2 in this.phases)
                            {
                                num7++;
                                str2 = str2 + num7.ToString();
                                string str5 = phase2.Condition.ToLower();
                                if (str5 != null)
                                {
                                    if (!(str5 == "health"))
                                    {
                                        if (str5 == "timer")
                                        {
                                            goto Label_0925;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\tuint32 " + str2 + "_Percent;");
                                    }
                                }
                                goto Label_093D;
                            Label_0925:
                                AddText(stream, "\r\n\tuint32 " + str2 + "_Timer;");
                            Label_093D:
                                str2 = "phase";
                            }
                            AddText(stream, "\r\n\tuint32 phase;\r\n");
                        }
                        if (this.textBox26.Text != "")
                        {
                            AddText(stream, "\r\n\tbool enraged;\r\n");
                        }
                        AddText(stream, "\r\n\tvoid EnterCombat(Unit *who)");
                        AddText(stream, "\r\n\t{");
                        if ((this.textBox28.Text != "") && ((str6 = this.comboBox11.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str6 == "yell"))
                            {
                                if (str6 == "say")
                                {
                                    goto Label_0A2D;
                                }
                                if (str6 == "emote")
                                {
                                    goto Label_0A50;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tm_creature->MonsterYell(\"" + this.textBox28.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_0A71;
                    Label_0A2D:
                        AddText(stream, "\r\n\t\tm_creature->MonsterSay(\"" + this.textBox28.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_0A71;
                    Label_0A50:
                        AddText(stream, "\r\n\t\tm_creature->MonsterTextEmote(+ \"" + this.textBox28.Text + "\", NULL, false);");
                    Label_0A71:
                        if ((num3 != 0) && ((str7 = this.comboBox7.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str7 == "self"))
                            {
                                if (str7 == "main tank")
                                {
                                    goto Label_0ADF;
                                }
                                if (str7 == "random")
                                {
                                    goto Label_0AFE;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tDoCast(m_creature, " + num3.ToString() + ");");
                            }
                        }
                        goto Label_0B1B;
                    Label_0ADF:
                        AddText(stream, "\r\n\t\tDoCast(m_creature->getVictim(), " + num3.ToString() + ");");
                        goto Label_0B1B;
                    Label_0AFE:
                        AddText(stream, "\r\n\t\tDoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num3.ToString() + ");");
                    Label_0B1B:
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid KilledUnit(Unit* victim)");
                        AddText(stream, "\r\n\t{");
                        if ((this.textBox29.Text != "") && ((str8 = this.comboBox12.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str8 == "yell"))
                            {
                                if (str8 == "say")
                                {
                                    goto Label_0BC5;
                                }
                                if (str8 == "emote")
                                {
                                    goto Label_0BE8;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tm_creature->MonsterYell(\"" + this.textBox29.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_0C09;
                    Label_0BC5:
                        AddText(stream, "\r\n\t\tm_creature->MonsterSay(\"" + this.textBox29.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_0C09;
                    Label_0BE8:
                        AddText(stream, "\r\n\t\tm_creature->MonsterTextEmote(\"" + this.textBox29.Text + "\", NULL, false);");
                    Label_0C09:
                        if ((num4 != 0) && ((str9 = this.comboBox8.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str9 == "self"))
                            {
                                if (str9 == "main tank")
                                {
                                    goto Label_0C77;
                                }
                                if (str9 == "random")
                                {
                                    goto Label_0C96;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tDoCast(m_creature, " + num4.ToString() + ");");
                            }
                        }
                        goto Label_0CB3;
                    Label_0C77:
                        AddText(stream, "\r\n\t\tDoCast(m_creature->getVictim(), " + num4.ToString() + ");");
                        goto Label_0CB3;
                    Label_0C96:
                        AddText(stream, "\r\n\t\tDoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num4.ToString() + ");");
                    Label_0CB3:
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid JustDied(Unit* Killer)");
                        AddText(stream, "\r\n\t{");
                        if ((this.textBox30.Text != "") && ((str10 = this.comboBox13.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str10 == "yell"))
                            {
                                if (str10 == "say")
                                {
                                    goto Label_0D5D;
                                }
                                if (str10 == "emote")
                                {
                                    goto Label_0D80;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tm_creature->MonsterYell(\"" + this.textBox30.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_0DA1;
                    Label_0D5D:
                        AddText(stream, "\r\n\t\tm_creature->MonsterSay(\"" + this.textBox30.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_0DA1;
                    Label_0D80:
                        AddText(stream, "\r\n\t\tm_creature->MonsterTextEmote(\"" + this.textBox30.Text + "\", NULL, false);");
                    Label_0DA1:
                        if ((num5 != 0) && ((str11 = this.comboBox9.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str11 == "self"))
                            {
                                if (str11 == "random")
                                {
                                    goto Label_0E10;
                                }
                                if (str11 == "main tank")
                                {
                                    goto Label_0E2F;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tDoCast(m_creature, " + num5.ToString() + ");");
                            }
                        }
                        goto Label_0E4C;
                    Label_0E10:
                        AddText(stream, "\r\n\t\tDoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num5.ToString() + ");");
                        goto Label_0E4C;
                    Label_0E2F:
                        AddText(stream, "\r\n\t\tDoCast(m_creature->getVictim(), " + num5.ToString() + ");");
                    Label_0E4C:
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid Reset()");
                        AddText(stream, "\r\n\t{");
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            foreach (Spell spell in this.nonPhasedSpells)
                            {
                                num7++;
                                str = str + num7.ToString();
                                if (spell.CastTimeHigh != 0)
                                {
                                    AddText(stream, "\r\n\t\t" + str + "_Timer = " + spell.CastTimeLow.ToString() + "+rand()%" + spell.CastTimeHigh.ToString() + ";");
                                }
                                else
                                {
                                    AddText(stream, "\r\n\t\t" + str + "_Timer = " + spell.CastTimeLow.ToString() + ";");
                                }
                                str = "spell";
                            }
                        }
                        num7 = 0;
                        num8 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase3 in this.phases)
                            {
                                num8++;
                                num7 = 0;
                                if (phase3.Spells.Count > 0)
                                {
                                    foreach (Spell spell2 in phase3.Spells)
                                    {
                                        num7++;
                                        str = str + num7.ToString();
                                        str2 = str2 + num8.ToString();
                                        if (spell2.CastTimeHigh != 0)
                                        {
                                            AddText(stream, "\r\n\t\t" + str + "_" + str2 + "_Timer = " + spell2.CastTimeLow.ToString() + "+rand()%" + spell2.CastTimeHigh.ToString() + ";");
                                        }
                                        else
                                        {
                                            AddText(stream, "\r\n\t\t" + str + "_" + str2 + "_Timer = " + spell2.CastTimeLow.ToString() + ";");
                                        }
                                        str = "spell";
                                        str2 = "phase";
                                    }
                                    continue;
                                }
                            }
                        }
                        num7 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase4 in this.phases)
                            {
                                num7++;
                                str2 = str2 + num7.ToString();
                                string str12 = phase4.Condition.ToLower();
                                if (str12 != null)
                                {
                                    if (!(str12 == "health"))
                                    {
                                        if (str12 == "timer")
                                        {
                                            goto Label_11F7;
                                        }
                                    }
                                    else
                                    {
                                        strArray = new string[5];
                                        strArray[0] = "\r\n\t\t";
                                        strArray[1] = str2;
                                        strArray[2] = "_Percent = ";
                                        int arguement = phase4.Arguement;
                                        strArray[3] = arguement.ToString();
                                        strArray[4] = ";";
                                        AddText(stream, string.Concat(strArray));
                                    }
                                }
                                goto Label_1252;
                            Label_11F7:
                                phase4.Arguement *= 0x3e8;
                                AddText(stream, string.Concat(new object[] { "\r\n\t\t", str2, "_Timer = ", phase4.Arguement, ";" }));
                            Label_1252:
                                str2 = "phase";
                            }
                            AddText(stream, "\r\n\t\tphase = 0;");
                            if (this.spellImmunities.Count > 0)
                            {
                                foreach (SpellImmunity immunity in this.spellImmunities)
                                {
                                    switch (immunity.School)
                                    {
                                        case "frost":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_FROST, true);");
                                            break;

                                        case "fire":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_FIRE, true);");
                                            break;

                                        case "nature":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_NATURE, true);");
                                            break;

                                        case "shadow":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_SHADOW, true);");
                                            break;

                                        case "arcane":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_ARCANE, true);");
                                            break;

                                        case "holy":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_HOLY, true);");
                                            break;

                                        case "physical":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_NORMAL, true);");
                                            break;
                                    }
                                    if (immunity.SpellId != 0)
                                    {
                                        AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(" + immunity.SpellId + ", IMMUNITY_DAMAGE, 0, true);");
                                    }
                                }
                            }
                            if (result != 0)
                            {
                                AddText(stream, "\r\n\t\tenraged = false;");
                            }
                        }
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid UpdateAI(const uint32 diff)");
                        AddText(stream, "\r\n\t{");
                        AddText(stream, "\r\n\t\tif (!UpdateVictim())");
                        AddText(stream, "\r\n\t\t\treturn;\r\n");
                        if (result == 0)
                        {
                            goto Label_160C;
                        }
                        AddText(stream, "\r\n\t\tif ((m_creature->GetHealth() * 100 / m_creature->GetMaxHealth() <= " + result + ") && !enraged)");
                        AddText(stream, "\r\n\t\t{");
                        AddText(stream, "\r\n\t\t\tenraged = true;");
                        if ((num2 != 0) && ((str3 = this.comboBox4.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "self"))
                            {
                                if (str3 == "random")
                                {
                                    goto Label_14FA;
                                }
                                if (str3 == "main tank")
                                {
                                    goto Label_1519;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\t\tDoCast(m_creature, " + num2.ToString() + ");");
                            }
                        }
                        goto Label_1536;
                    Label_14FA:
                        AddText(stream, "\r\n\t\t\tDoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num2.ToString() + ");");
                        goto Label_1536;
                    Label_1519:
                        AddText(stream, "\r\n\t\t\tDoCast(m_creature->getVictim(), " + num2.ToString() + ");");
                    Label_1536:
                        if ((this.textBox27.Text != "") && ((str3 = this.comboBox10.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "yell"))
                            {
                                if (str3 == "say")
                                {
                                    goto Label_15BC;
                                }
                                if (str3 == "emote")
                                {
                                    goto Label_15DF;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\t\tm_creature->MonsterYell(\"" + this.textBox27.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_1600;
                    Label_15BC:
                        AddText(stream, "\r\n\t\t\tm_creature->MonsterSay(\"" + this.textBox27.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_1600;
                    Label_15DF:
                        AddText(stream, "\r\n\t\t\tm_creature->MonsterTextEmote(\"" + this.textBox27.Text + "\", NULL, false);");
                    Label_1600:
                        AddText(stream, "\r\n\t\t}\r\n");
                    Label_160C:
                        num7 = 0;
                        num9 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase5 in this.phases)
                            {
                                num7++;
                                str2 = str2 + num7.ToString();
                                str3 = phase5.Condition.ToLower();
                                if (str3 == null)
                                {
                                    goto Label_190E;
                                }
                                if (!(str3 == "health"))
                                {
                                    if (str3 == "timer")
                                    {
                                        goto Label_17C3;
                                    }
                                    goto Label_190E;
                                }
                                AddText(stream, string.Concat(new object[] { "\r\n\t\tif ((m_creature->GetHealth() * 100 / m_creature->GetMaxHealth() <= ", phase5.Arguement, ") && phase == ", num9.ToString(), ")" }));
                                AddText(stream, "\r\n\t\t{");
                                AddText(stream, "\r\n\t\t\tphase = " + num7.ToString() + ";");
                                if ((phase5.Text != "") && ((str3 = phase5.ChatType.ToLower()) != null))
                                {
                                    if (!(str3 == "yell"))
                                    {
                                        if (str3 == "say")
                                        {
                                            goto Label_1776;
                                        }
                                        if (str3 == "emote")
                                        {
                                            goto Label_1795;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\tm_creature->MonsterYell(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                    }
                                }
                                goto Label_17B2;
                            Label_1776:
                                AddText(stream, "\r\n\t\t\tm_creature->MonsterSay(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                goto Label_17B2;
                            Label_1795:
                                AddText(stream, "\r\n\t\t\tm_creature->MonsterTextEmote(\"" + phase5.Text + "\", NULL, false);");
                            Label_17B2:
                                AddText(stream, "\r\n\t\t}\r\n");
                                goto Label_190E;
                            Label_17C3:
                                AddText(stream, "\r\n\t\tif (phase == " + num9.ToString() + ")");
                                AddText(stream, "\r\n\t\t{");
                                AddText(stream, "\r\n\t\t\tif (" + str2 + "_Timer <= diff)");
                                AddText(stream, "\r\n\t\t\t{");
                                AddText(stream, "\r\n\t\t\t\tphase = " + num7.ToString() + ";");
                                if ((phase5.Text != "") && ((str3 = phase5.ChatType.ToLower()) != null))
                                {
                                    if (!(str3 == "yell"))
                                    {
                                        if (str3 == "say")
                                        {
                                            goto Label_18A2;
                                        }
                                        if (str3 == "emote")
                                        {
                                            goto Label_18C1;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\t\tm_creature->MonsterYell(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                    }
                                }
                                goto Label_18DE;
                            Label_18A2:
                                AddText(stream, "\r\n\t\t\t\tm_creature->MonsterSay(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                goto Label_18DE;
                            Label_18C1:
                                AddText(stream, "\r\n\t\t\t\tm_creature->MonsterTextEmote(\"" + phase5.Text + "\", NULL, false);");
                            Label_18DE:
                                AddText(stream, "\r\n\t\t\t}");
                                AddText(stream, "\r\n\t\t\telse " + str2 + "_Timer -= diff;");
                                AddText(stream, "\r\n\t\t}\r\n");
                            Label_190E:
                                str2 = "phase";
                                num9++;
                            }
                        }
                        num7 = 0;
                        num8 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase6 in this.phases)
                            {
                                num8++;
                                num7 = 0;
                                do
                                {
                                    AddText(stream, "\r\n\t\tif (phase == " + num8.ToString() + ")");
                                    AddText(stream, "\r\n\t\t{");
                                }
                                while (num8 != phase6.Id);
                                foreach (Spell spell3 in phase6.Spells)
                                {
                                    num7++;
                                    str = str + num7.ToString();
                                    str2 = str2 + num8.ToString();
                                    AddText(stream, "\r\n\r\n\t\t\tif (" + str + "_" + str2 + "_Timer <= diff)");
                                    AddText(stream, "\r\n\t\t\t{");
                                    str3 = spell3.Target.ToLower();
                                    if (str3 != null)
                                    {
                                        if (!(str3 == "self"))
                                        {
                                            if (str3 == "main tank")
                                            {
                                                goto Label_1A95;
                                            }
                                            if (str3 == "random")
                                            {
                                                goto Label_1AB9;
                                            }
                                        }
                                        else
                                        {
                                            AddText(stream, "\r\n\t\t\t\tDoCast(m_creature, " + spell3.SpellId + ");");
                                        }
                                    }
                                    goto Label_1ADB;
                                Label_1A95:
                                    AddText(stream, "\r\n\t\t\t\tDoCast(m_creature->getVictim(), " + spell3.SpellId + ");");
                                    goto Label_1ADB;
                                Label_1AB9:
                                    AddText(stream, "\r\n\t\t\t\tDoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + spell3.SpellId + ");");
                                Label_1ADB:
                                    if (spell3.CastTimeHigh != 0)
                                    {
                                        AddText(stream, "\r\n\t\t\t\t" + str + "_" + str2 + "_Timer = " + spell3.CastTimeLow.ToString() + "+rand()%" + spell3.CastTimeHigh.ToString() + ";");
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\t\t" + str + "_" + str2 + "_Timer = " + spell3.CastTimeLow.ToString() + ";");
                                    }
                                    AddText(stream, "\r\n\t\t\t} else " + str + "_" + str2 + "_Timer -= diff;");
                                    str = "spell";
                                    str2 = "phase";
                                }
                                AddText(stream, "\r\n\t\t}\r\n");
                            }
                        }
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            foreach (Spell spell4 in this.nonPhasedSpells)
                            {
                                num7++;
                                str = str + num7.ToString();
                                AddText(stream, "\r\n\t\tif (" + str + "_Timer <= diff)");
                                AddText(stream, "\r\n\t\t{");
                                str3 = spell4.Target.ToLower();
                                if (str3 != null)
                                {
                                    if (!(str3 == "self"))
                                    {
                                        if (str3 == "main tank")
                                        {
                                            goto Label_1D08;
                                        }
                                        if (str3 == "random")
                                        {
                                            goto Label_1D2C;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\tDoCast(m_creature, " + spell4.SpellId + ");");
                                    }
                                }
                                goto Label_1D4E;
                            Label_1D08:
                                AddText(stream, "\r\n\t\t\tDoCast(m_creature->getVictim(), " + spell4.SpellId + ");");
                                goto Label_1D4E;
                            Label_1D2C:
                                AddText(stream, "\r\n\t\t\tDoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + spell4.SpellId + ");");
                            Label_1D4E:
                                if (spell4.CastTimeHigh != 0)
                                {
                                    AddText(stream, "\r\n\t\t\t" + str + "_Timer = " + spell4.CastTimeLow.ToString() + "+rand()%" + spell4.CastTimeHigh.ToString() + ";");
                                }
                                else
                                {
                                    AddText(stream, "\r\n\t\t\t" + str + "_Timer = " + spell4.CastTimeLow.ToString() + ";");
                                }
                                AddText(stream, "\r\n\t\t} else " + str + "_Timer -= diff;\r\n");
                                str = "spell";
                            }
                        }
                        AddText(stream, "\r\n\t\tDoMeleeAttackIfReady();");
                        AddText(stream, "\r\n\t}");
                        AddText(stream, "\r\n};");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\nCreatureAI* GetAI" + this.textBox1.Text + "(Creature* pCreature)");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n\treturn new " + this.textBox1.Text + "AI (pCreature);");
                        AddText(stream, "\r\n}\r\n");
                        AddText(stream, "\r\nvoid AddSC_" + this.textBox1.Text + "()");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n\tScript *newscript;");
                        AddText(stream, "\r\n\tnewscript = new Script;");
                        AddText(stream, "\r\n\tnewscript->Name = \"npc_" + this.textBox1.Text + "\";");
                        AddText(stream, "\r\n\tnewscript->GetAI = &GetAI" + this.textBox1.Text + ";");
                        AddText(stream, "\r\n\tnewscript->RegisterSelf();");
                        AddText(stream, "\r\n}");
                        goto Label_38F9;
                    Label_1F69:
                        AddText(stream, "// Script Generated: " + DateTime.Now);
                        AddText(stream, "\r\n// Run this query on your world database");
                        AddText(stream, "\r\n// UPDATE `creature_template` SET ScriptName='npc_" + this.textBox1.Text + "' WHERE `entry`=" + num6.ToString() + ";");
                        AddText(stream, "\r\n#include \"precompiled.h\"\r\n");
                        AddText(stream, "\r\n\nstruct MANGOS_DLL_DECL " + this.textBox1.Text + "AI : public ScriptedAI");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n\t" + this.textBox1.Text + "AI(Creature* pCreature) : ScriptedAI(pCreature)");
                        AddText(stream, "\r\n\t{");
                        AddText(stream, "\r\n\t\tReset();");
                        if (((this.comboBox4.SelectedItem != null) && ((str3 = this.comboBox6.SelectedItem.ToString().ToLower()) != null)) && (!(str3 == "true") && (str3 == "false")))
                        {
                            AddText(stream, "\r\n\t\tSetCombatMovement(false);");
                        }
                        AddText(stream, "\r\n\t}\r\n");
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            using (enumerator = this.nonPhasedSpells.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    Spell local3 = enumerator.Current;
                                    num7++;
                                    str = str + num7.ToString();
                                    AddText(stream, "\r\n\tuint32 " + str + "_Timer;");
                                    str = "spell";
                                }
                            }
                        }
                        num7 = 0;
                        num8 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase7 in this.phases)
                            {
                                num8++;
                                num7 = 0;
                                if (phase7.Spells.Count > 0)
                                {
                                    using (enumerator = phase7.Spells.GetEnumerator())
                                    {
                                        while (enumerator.MoveNext())
                                        {
                                            Spell local4 = enumerator.Current;
                                            num7++;
                                            str = str + num7.ToString();
                                            str2 = str2 + num8.ToString();
                                            AddText(stream, "\r\n\tuint32 " + str + "_" + str2 + "_Timer;");
                                            str = "spell";
                                            str2 = "phase";
                                        }
                                        continue;
                                    }
                                }
                            }
                        }
                        num7 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase8 in this.phases)
                            {
                                num7++;
                                str2 = str2 + num7.ToString();
                                str3 = phase8.Condition.ToLower();
                                if (str3 != null)
                                {
                                    if (!(str3 == "health"))
                                    {
                                        if (str3 == "timer")
                                        {
                                            goto Label_22BA;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\tuint32 " + str2 + "_Percent;");
                                    }
                                }
                                goto Label_22D2;
                            Label_22BA:
                                AddText(stream, "\r\n\tuint32 " + str2 + "_Timer;");
                            Label_22D2:
                                str2 = "phase";
                            }
                            AddText(stream, "\r\n\tuint32 phase;\r\n");
                        }
                        if (this.textBox26.Text != "")
                        {
                            AddText(stream, "\r\n\tbool enraged;\r\n");
                        }
                        AddText(stream, "\r\n\tvoid Aggro(Unit* pWho)");
                        AddText(stream, "\r\n\t{");
                        if ((this.textBox28.Text != "") && ((str3 = this.comboBox11.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "yell"))
                            {
                                if (str3 == "say")
                                {
                                    goto Label_23C2;
                                }
                                if (str3 == "emote")
                                {
                                    goto Label_23E5;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tm_creature->MonsterYell(\"" + this.textBox28.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_2406;
                    Label_23C2:
                        AddText(stream, "\r\n\t\tm_creature->MonsterSay(\"" + this.textBox28.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_2406;
                    Label_23E5:
                        AddText(stream, "\r\n\t\tm_creature->MonsterTextEmote(+ \"" + this.textBox28.Text + "\", NULL, false);");
                    Label_2406:
                        if ((num3 != 0) && ((str3 = this.comboBox7.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "self"))
                            {
                                if (str3 == "main tank")
                                {
                                    goto Label_2474;
                                }
                                if (str3 == "random")
                                {
                                    goto Label_2493;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tDoCastSpellIfCan(m_creature, " + num3.ToString() + ");");
                            }
                        }
                        goto Label_24B0;
                    Label_2474:
                        AddText(stream, "\r\n\t\tDoCastSpellIfCan(m_creature->getVictim(), " + num3.ToString() + ");");
                        goto Label_24B0;
                    Label_2493:
                        AddText(stream, "\r\n\t\tDoCastSpellIfCan(SelectUnit(SELECT_TARGET_RANDOM, 0), " + num3.ToString() + ");");
                    Label_24B0:
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid KilledUnit(Unit* pVictim)");
                        AddText(stream, "\r\n\t{");
                        if ((this.textBox29.Text != "") && ((str3 = this.comboBox12.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "yell"))
                            {
                                if (str3 == "say")
                                {
                                    goto Label_255A;
                                }
                                if (str3 == "emote")
                                {
                                    goto Label_257D;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tm_creature->MonsterYell(\"" + this.textBox29.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_259E;
                    Label_255A:
                        AddText(stream, "\r\n\t\tm_creature->MonsterSay(\"" + this.textBox29.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_259E;
                    Label_257D:
                        AddText(stream, "\r\n\t\tm_creature->MonsterTextEmote(\"" + this.textBox29.Text + "\", NULL, false);");
                    Label_259E:
                        if ((num4 != 0) && ((str3 = this.comboBox8.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "self"))
                            {
                                if (str3 == "main tank")
                                {
                                    goto Label_260C;
                                }
                                if (str3 == "random")
                                {
                                    goto Label_262B;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tDoCastSpellIfCan(m_creature, " + num4.ToString() + ");");
                            }
                        }
                        goto Label_2648;
                    Label_260C:
                        AddText(stream, "\r\n\t\tDoCastSpellIfCan(m_creature->getVictim(), " + num4.ToString() + ");");
                        goto Label_2648;
                    Label_262B:
                        AddText(stream, "\r\n\t\tDoCastSpellIfCan(SelectUnit(SELECT_TARGET_RANDOM, 0), " + num4.ToString() + ");");
                    Label_2648:
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid JustDied(Unit* pKiller)");
                        AddText(stream, "\r\n\t{");
                        if ((this.textBox30.Text != "") && ((str3 = this.comboBox13.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "yell"))
                            {
                                if (str3 == "say")
                                {
                                    goto Label_26F2;
                                }
                                if (str3 == "emote")
                                {
                                    goto Label_2715;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tm_creature->MonsterYell(\"" + this.textBox30.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_2736;
                    Label_26F2:
                        AddText(stream, "\r\n\t\tm_creature->MonsterSay(\"" + this.textBox30.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_2736;
                    Label_2715:
                        AddText(stream, "\r\n\t\tm_creature->MonsterTextEmote(\"" + this.textBox30.Text + "\", NULL, false);");
                    Label_2736:
                        if ((num5 != 0) && ((str3 = this.comboBox9.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "self"))
                            {
                                if (str3 == "random")
                                {
                                    goto Label_27A5;
                                }
                                if (str3 == "main tank")
                                {
                                    goto Label_27C4;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\tDoCastSpellIfCan(m_creature, " + num5.ToString() + ");");
                            }
                        }
                        goto Label_27E1;
                    Label_27A5:
                        AddText(stream, "\r\n\t\tDoCastSpellIfCan(SelectUnit(SELECT_TARGET_RANDOM, 0), " + num5.ToString() + ");");
                        goto Label_27E1;
                    Label_27C4:
                        AddText(stream, "\r\n\t\tDoCastSpellIfCan(m_creature->getVictim(), " + num5.ToString() + ");");
                    Label_27E1:
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid Reset()");
                        AddText(stream, "\r\n\t{");
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            foreach (Spell spell5 in this.nonPhasedSpells)
                            {
                                num7++;
                                str = str + num7.ToString();
                                if (spell5.CastTimeHigh != 0)
                                {
                                    AddText(stream, "\r\n\t\t" + str + "_Timer = " + spell5.CastTimeLow.ToString() + "+rand()%" + spell5.CastTimeHigh.ToString() + ";");
                                }
                                else
                                {
                                    AddText(stream, "\r\n\t\t" + str + "_Timer = " + spell5.CastTimeLow.ToString() + ";");
                                }
                                str = "spell";
                            }
                        }
                        num7 = 0;
                        num8 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase9 in this.phases)
                            {
                                num8++;
                                num7 = 0;
                                if (phase9.Spells.Count > 0)
                                {
                                    foreach (Spell spell6 in phase9.Spells)
                                    {
                                        num7++;
                                        str = str + num7.ToString();
                                        str2 = str2 + num8.ToString();
                                        if (spell6.CastTimeHigh != 0)
                                        {
                                            AddText(stream, "\r\n\t\t" + str + "_" + str2 + "_Timer = " + spell6.CastTimeLow.ToString() + "+rand()%" + spell6.CastTimeHigh.ToString() + ";");
                                        }
                                        else
                                        {
                                            AddText(stream, "\r\n\t\t" + str + "_" + str2 + "_Timer = " + spell6.CastTimeLow.ToString() + ";");
                                        }
                                        str = "spell";
                                        str2 = "phase";
                                    }
                                    continue;
                                }
                            }
                        }
                        num7 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase10 in this.phases)
                            {
                                num7++;
                                str2 = str2 + num7.ToString();
                                str3 = phase10.Condition.ToLower();
                                if (str3 != null)
                                {
                                    if (!(str3 == "health"))
                                    {
                                        if (str3 == "timer")
                                        {
                                            goto Label_2B8C;
                                        }
                                    }
                                    else
                                    {
                                        strArray = new string[] { "\r\n\t\t", str2, "_Percent = ", phase10.Arguement.ToString(), ";" };
                                        AddText(stream, string.Concat(strArray));
                                    }
                                }
                                goto Label_2BE7;
                            Label_2B8C:
                                phase10.Arguement *= 0x3e8;
                                AddText(stream, string.Concat(new object[] { "\r\n\t\t", str2, "_Timer = ", phase10.Arguement, ";" }));
                            Label_2BE7:
                                str2 = "phase";
                            }
                            AddText(stream, "\r\n\t\tphase = 0;");
                            if (this.spellImmunities.Count > 0)
                            {
                                foreach (SpellImmunity immunity2 in this.spellImmunities)
                                {
                                    switch (immunity2.School)
                                    {
                                        case "frost":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_FROST, true);");
                                            break;

                                        case "fire":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_FIRE, true);");
                                            break;

                                        case "nature":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_NATURE, true);");
                                            break;

                                        case "shadow":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_SHADOW, true);");
                                            break;

                                        case "arcane":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_ARCANE, true);");
                                            break;

                                        case "holy":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_HOLY, true);");
                                            break;

                                        case "physical":
                                            AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_NORMAL, true);");
                                            break;
                                    }
                                    if (immunity2.SpellId != 0)
                                    {
                                        AddText(stream, "\r\n\t\tm_creature->ApplySpellImmune(" + immunity2.SpellId + ", IMMUNITY_DAMAGE, 0, true);");
                                    }
                                }
                            }
                            if (result != 0)
                            {
                                AddText(stream, "\r\n\t\tenraged = false;");
                            }
                        }
                        AddText(stream, "\r\n\t}\r\n");
                        AddText(stream, "\r\n\tvoid UpdateAI(const uint32 diff)");
                        AddText(stream, "\r\n\t{");
                        AddText(stream, "\r\n\t\tif (!m_creature->SelectHostileTarget() || !m_creature->getVictim())");
                        AddText(stream, "\r\n\t\t\treturn;\r\n");
                        if (result == 0)
                        {
                            goto Label_2FA1;
                        }
                        AddText(stream, "\r\n\t\tif ((m_creature->GetHealth() * 100 / m_creature->GetMaxHealth() <= " + result + ") && !enraged)");
                        AddText(stream, "\r\n\t\t{");
                        AddText(stream, "\r\n\t\t\tenraged = true;");
                        if ((num2 != 0) && ((str3 = this.comboBox4.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "self"))
                            {
                                if (str3 == "random")
                                {
                                    goto Label_2E8F;
                                }
                                if (str3 == "main tank")
                                {
                                    goto Label_2EAE;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\t\tDoCastSpellIfCan(m_creature, " + num2.ToString() + ");");
                            }
                        }
                        goto Label_2ECB;
                    Label_2E8F:
                        AddText(stream, "\r\n\t\t\tDoCastSpellIfCan(SelectUnit(SELECT_TARGET_RANDOM, 0), " + num2.ToString() + ");");
                        goto Label_2ECB;
                    Label_2EAE:
                        AddText(stream, "\r\n\t\t\tDoCastSpellIfCan(m_creature->getVictim(), " + num2.ToString() + ");");
                    Label_2ECB:
                        if ((this.textBox27.Text != "") && ((str3 = this.comboBox10.SelectedItem.ToString().ToLower()) != null))
                        {
                            if (!(str3 == "yell"))
                            {
                                if (str3 == "say")
                                {
                                    goto Label_2F51;
                                }
                                if (str3 == "emote")
                                {
                                    goto Label_2F74;
                                }
                            }
                            else
                            {
                                AddText(stream, "\r\n\t\t\tm_creature->MonsterYell(\"" + this.textBox27.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_2F95;
                    Label_2F51:
                        AddText(stream, "\r\n\t\t\tm_creature->MonsterSay(\"" + this.textBox27.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_2F95;
                    Label_2F74:
                        AddText(stream, "\r\n\t\t\tm_creature->MonsterTextEmote(\"" + this.textBox27.Text + "\", NULL, false);");
                    Label_2F95:
                        AddText(stream, "\r\n\t\t}\r\n");
                    Label_2FA1:
                        num7 = 0;
                        num9 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase11 in this.phases)
                            {
                                num7++;
                                str2 = str2 + num7.ToString();
                                str3 = phase11.Condition.ToLower();
                                if (str3 == null)
                                {
                                    goto Label_32A3;
                                }
                                if (!(str3 == "health"))
                                {
                                    if (str3 == "timer")
                                    {
                                        goto Label_3158;
                                    }
                                    goto Label_32A3;
                                }
                                AddText(stream, string.Concat(new object[] { "\r\n\t\tif ((m_creature->GetHealth() * 100 / m_creature->GetMaxHealth() <= ", phase11.Arguement, ") && phase == ", num9.ToString(), ")" }));
                                AddText(stream, "\r\n\t\t{");
                                AddText(stream, "\r\n\t\t\tphase = " + num7.ToString() + ";");
                                if ((phase11.Text != "") && ((str3 = phase11.ChatType.ToLower()) != null))
                                {
                                    if (!(str3 == "yell"))
                                    {
                                        if (str3 == "say")
                                        {
                                            goto Label_310B;
                                        }
                                        if (str3 == "emote")
                                        {
                                            goto Label_312A;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\tm_creature->MonsterYell(\"" + phase11.Text + "\", LANG_UNIVERSAL, NULL);");
                                    }
                                }
                                goto Label_3147;
                            Label_310B:
                                AddText(stream, "\r\n\t\t\tm_creature->MonsterSay(\"" + phase11.Text + "\", LANG_UNIVERSAL, NULL);");
                                goto Label_3147;
                            Label_312A:
                                AddText(stream, "\r\n\t\t\tm_creature->MonsterTextEmote(\"" + phase11.Text + "\", NULL, false);");
                            Label_3147:
                                AddText(stream, "\r\n\t\t}\r\n");
                                goto Label_32A3;
                            Label_3158:
                                AddText(stream, "\r\n\t\tif (phase == " + num9.ToString() + ")");
                                AddText(stream, "\r\n\t\t{");
                                AddText(stream, "\r\n\t\t\tif (" + str2 + "_Timer <= diff)");
                                AddText(stream, "\r\n\t\t\t{");
                                AddText(stream, "\r\n\t\t\t\tphase = " + num7.ToString() + ";");
                                if ((phase11.Text != "") && ((str3 = phase11.ChatType.ToLower()) != null))
                                {
                                    if (!(str3 == "yell"))
                                    {
                                        if (str3 == "say")
                                        {
                                            goto Label_3237;
                                        }
                                        if (str3 == "emote")
                                        {
                                            goto Label_3256;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\t\tm_creature->MonsterYell(\"" + phase11.Text + "\", LANG_UNIVERSAL, NULL);");
                                    }
                                }
                                goto Label_3273;
                            Label_3237:
                                AddText(stream, "\r\n\t\t\t\tm_creature->MonsterSay(\"" + phase11.Text + "\", LANG_UNIVERSAL, NULL);");
                                goto Label_3273;
                            Label_3256:
                                AddText(stream, "\r\n\t\t\t\tm_creature->MonsterTextEmote(\"" + phase11.Text + "\", NULL, false);");
                            Label_3273:
                                AddText(stream, "\r\n\t\t\t}");
                                AddText(stream, "\r\n\t\t\telse " + str2 + "_Timer -= diff;");
                                AddText(stream, "\r\n\t\t}\r\n");
                            Label_32A3:
                                str2 = "phase";
                                num9++;
                            }
                        }
                        num7 = 0;
                        num8 = 0;
                        if (this.phases.Count > 0)
                        {
                            foreach (Phase phase12 in this.phases)
                            {
                                num8++;
                                num7 = 0;
                                do
                                {
                                    AddText(stream, "\r\n\t\tif (phase == " + num8.ToString() + ")");
                                    AddText(stream, "\r\n\t\t{");
                                }
                                while (num8 != phase12.Id);
                                foreach (Spell spell7 in phase12.Spells)
                                {
                                    num7++;
                                    str = str + num7.ToString();
                                    str2 = str2 + num8.ToString();
                                    AddText(stream, "\r\n\r\n\t\t\tif (" + str + "_" + str2 + "_Timer <= diff)");
                                    AddText(stream, "\r\n\t\t\t{");
                                    str3 = spell7.Target.ToLower();
                                    if (str3 != null)
                                    {
                                        if (!(str3 == "self"))
                                        {
                                            if (str3 == "main tank")
                                            {
                                                goto Label_342A;
                                            }
                                            if (str3 == "random")
                                            {
                                                goto Label_344E;
                                            }
                                        }
                                        else
                                        {
                                            AddText(stream, "\r\n\t\t\t\tDoCastSpellIfCan(m_creature, " + spell7.SpellId + ");");
                                        }
                                    }
                                    goto Label_3470;
                                Label_342A:
                                    AddText(stream, "\r\n\t\t\t\tDoCastSpellIfCan(m_creature->getVictim(), " + spell7.SpellId + ");");
                                    goto Label_3470;
                                Label_344E:
                                    AddText(stream, "\r\n\t\t\t\tDoCastSpellIfCan(SelectUnit(SELECT_TARGET_RANDOM, 0), " + spell7.SpellId + ");");
                                Label_3470:
                                    if (spell7.CastTimeHigh != 0)
                                    {
                                        AddText(stream, "\r\n\t\t\t\t" + str + "_" + str2 + "_Timer = " + spell7.CastTimeLow.ToString() + "+rand()%" + spell7.CastTimeHigh.ToString() + ";");
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\t\t" + str + "_" + str2 + "_Timer = " + spell7.CastTimeLow.ToString() + ";");
                                    }
                                    AddText(stream, "\r\n\t\t\t} else " + str + "_" + str2 + "_Timer -= diff;");
                                    str = "spell";
                                    str2 = "phase";
                                }
                                AddText(stream, "\r\n\t\t}\r\n");
                            }
                        }
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            foreach (Spell spell8 in this.nonPhasedSpells)
                            {
                                num7++;
                                str = str + num7.ToString();
                                AddText(stream, "\r\n\t\tif (" + str + "_Timer <= diff)");
                                AddText(stream, "\r\n\t\t{");
                                str3 = spell8.Target.ToLower();
                                if (str3 != null)
                                {
                                    if (!(str3 == "self"))
                                    {
                                        if (str3 == "main tank")
                                        {
                                            goto Label_369D;
                                        }
                                        if (str3 == "random")
                                        {
                                            goto Label_36C1;
                                        }
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n\t\t\tDoCastSpellIfCan(m_creature, " + spell8.SpellId + ");");
                                    }
                                }
                                goto Label_36E3;
                            Label_369D:
                                AddText(stream, "\r\n\t\t\tDoCastSpellIfCan(m_creature->getVictim(), " + spell8.SpellId + ");");
                                goto Label_36E3;
                            Label_36C1:
                                AddText(stream, "\r\n\t\t\tDoCastSpellIfCan(SelectUnit(SELECT_TARGET_RANDOM, 0), " + spell8.SpellId + ");");
                            Label_36E3:
                                if (spell8.CastTimeHigh != 0)
                                {
                                    AddText(stream, "\r\n\t\t\t" + str + "_Timer = " + spell8.CastTimeLow.ToString() + "+rand()%" + spell8.CastTimeHigh.ToString() + ";");
                                }
                                else
                                {
                                    AddText(stream, "\r\n\t\t\t" + str + "_Timer = " + spell8.CastTimeLow.ToString() + ";");
                                }
                                AddText(stream, "\r\n\t\t} else " + str + "_Timer -= diff;\r\n");
                                str = "spell";
                            }
                        }
                        AddText(stream, "\r\n\t\tDoMeleeAttackIfReady();");
                        AddText(stream, "\r\n\t}");
                        AddText(stream, "\r\n};");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\nCreatureAI* GetAI" + this.textBox1.Text + "(Creature* pCreature)");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n\treturn new " + this.textBox1.Text + "AI (pCreature);");
                        AddText(stream, "\r\n}\r\n");
                        AddText(stream, "\r\nvoid AddSC_" + this.textBox1.Text + "()");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n\tScript *newscript;");
                        AddText(stream, "\r\n\tnewscript = new Script;");
                        AddText(stream, "\r\n\tnewscript->Name = \"npc_" + this.textBox1.Text + "\";");
                        AddText(stream, "\r\n\tnewscript->GetAI = &GetAI" + this.textBox1.Text + ";");
                        AddText(stream, "\r\n\tnewscript->RegisterSelf();");
                        AddText(stream, "\r\n}");
                    Label_38F9:
                        MessageBox.Show("Script completed successfully");
                    }
                    num7 = 1;
                    foreach (Phase phase13 in this.phases)
                    {
                        phase13.Spells.Clear();
                    }
                    this.phases.Clear();
                    this.nonPhasedSpells.Clear();
                    this.textBox13.Clear();
                    this.textBox14.Clear();
                    this.textBox15.Clear();
                    this.textBox18.Clear();
                    this.textBox20.Clear();
                    this.textBox16.Clear();
                    this.textBox19.Clear();
                    this.textBox18.Clear();
                    this.textBox20.Clear();
                    this.textBox10.Clear();
                    this.textBox11.Clear();
                    this.textBox3.Clear();
                    this.textBox4.Clear();
                    this.textBox5.Clear();
                    this.textBox6.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    this.textBox9.Clear();
                    this.textBox17.Clear();
                    this.textBox21.Clear();
                    this.textBox23.Clear();
                    this.textBox24.Clear();
                    this.textBox25.Clear();
                    this.textBox26.Clear();
                    this.textBox27.Clear();
                    this.textBox28.Clear();
                    this.textBox29.Clear();
                    this.textBox30.Clear();
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox22.Clear();
                    this.textBox12.Clear();
                    this.comboBox14.SelectedItem = null;
                    this.comboBox3.SelectedItem = null;
                    this.comboBox5.SelectedItem = null;
                    this.comboBox1.SelectedItem = null;
                    this.comboBox4.SelectedItem = null;
                    this.comboBox7.SelectedItem = null;
                    this.comboBox8.SelectedItem = null;
                    this.comboBox9.SelectedItem = null;
                    this.comboBox10.SelectedItem = null;
                    this.comboBox11.SelectedItem = null;
                    this.comboBox12.SelectedItem = null;
                    this.comboBox13.SelectedItem = null;
                    this.comboBox6.SelectedItem = null;
                    this.comboBox2.SelectedItem = null;
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int result = 0;
            string school = "";
            if ((this.textBox12.Text == "") && (this.comboBox14.SelectedItem == null))
            {
                MessageBox.Show("You must have a specified spell id or school for a spell immunity!");
            }
            else if ((this.textBox12.Text != "") && !int.TryParse(this.textBox12.Text, out result))
            {
                MessageBox.Show("Spell Id must be a number!");
            }
            else
            {
                if (this.comboBox14.SelectedItem != null)
                {
                    school = this.comboBox14.SelectedItem.ToString().ToLower();
                    this.textBox11.Text = this.textBox11.Text + this.comboBox14.SelectedItem.ToString() + "\r\n";
                }
                else
                {
                    this.textBox11.Text = this.textBox11.Text + "x\r\n";
                }
                if (this.textBox12.Text != "")
                {
                    this.textBox10.Text = this.textBox10.Text + result.ToString() + "\r\n";
                }
                else
                {
                    this.textBox10.Text = this.textBox10.Text + "x\r\n";
                }
                this.AddSpellImmunity(result, school);
                this.textBox12.Clear();
                this.comboBox14.SelectedItem = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Phase FindPhaseById(int id)
        {
            Phase phase = this.phases.Find(pPhase => pPhase.Id == id);
            if (phase == null)
            {
                return null;
            }
            return phase;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.label1 = new Label();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.textBox3 = new TextBox();
            this.textBox4 = new TextBox();
            this.label3 = new Label();
            this.textBox5 = new TextBox();
            this.textBox6 = new TextBox();
            this.label4 = new Label();
            this.textBox7 = new TextBox();
            this.textBox8 = new TextBox();
            this.label5 = new Label();
            this.comboBox1 = new ComboBox();
            this.textBox9 = new TextBox();
            this.label6 = new Label();
            this.textBox13 = new TextBox();
            this.label9 = new Label();
            this.textBox14 = new TextBox();
            this.comboBox3 = new ComboBox();
            this.label10 = new Label();
            this.label11 = new Label();
            this.textBox15 = new TextBox();
            this.textBox16 = new TextBox();
            this.textBox17 = new TextBox();
            this.label12 = new Label();
            this.button2 = new Button();
            this.textBox18 = new TextBox();
            this.label13 = new Label();
            this.label14 = new Label();
            this.textBox19 = new TextBox();
            this.textBox20 = new TextBox();
            this.comboBox5 = new ComboBox();
            this.comboBox6 = new ComboBox();
            this.label15 = new Label();
            this.textBox21 = new TextBox();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label18 = new Label();
            this.label19 = new Label();
            this.label20 = new Label();
            this.textBox22 = new TextBox();
            this.textBox23 = new TextBox();
            this.textBox24 = new TextBox();
            this.textBox25 = new TextBox();
            this.label21 = new Label();
            this.comboBox4 = new ComboBox();
            this.comboBox7 = new ComboBox();
            this.comboBox8 = new ComboBox();
            this.comboBox9 = new ComboBox();
            this.label22 = new Label();
            this.comboBox10 = new ComboBox();
            this.comboBox11 = new ComboBox();
            this.comboBox12 = new ComboBox();
            this.comboBox13 = new ComboBox();
            this.textBox26 = new TextBox();
            this.label23 = new Label();
            this.button3 = new Button();
            this.label24 = new Label();
            this.label25 = new Label();
            this.toolTip1 = new ToolTip(this.components);
            this.toolTip2 = new ToolTip(this.components);
            this.label26 = new Label();
            this.textBox27 = new TextBox();
            this.textBox28 = new TextBox();
            this.textBox29 = new TextBox();
            this.textBox30 = new TextBox();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.tabPage2 = new TabPage();
            this.tabPage3 = new TabPage();
            this.tabPage4 = new TabPage();
            this.button4 = new Button();
            this.textBox12 = new TextBox();
            this.comboBox14 = new ComboBox();
            this.label29 = new Label();
            this.textBox11 = new TextBox();
            this.label28 = new Label();
            this.label27 = new Label();
            this.textBox10 = new TextBox();
            this.label8 = new Label();
            this.comboBox2 = new ComboBox();
            this.label7 = new Label();
            this.toolTip3 = new ToolTip(this.components);
            this.toolTip4 = new ToolTip(this.components);
            this.toolTip5 = new ToolTip(this.components);
            this.toolTip6 = new ToolTip(this.components);
            this.toolTip7 = new ToolTip(this.components);
            this.toolTip8 = new ToolTip(this.components);
            this.toolTip9 = new ToolTip(this.components);
            this.toolTip10 = new ToolTip(this.components);
            this.toolTip11 = new ToolTip(this.components);
            this.toolTip12 = new ToolTip(this.components);
            this.toolTip13 = new ToolTip(this.components);
            this.toolTip14 = new ToolTip(this.components);
            this.toolTip15 = new ToolTip(this.components);
            this.toolTip16 = new ToolTip(this.components);
            this.toolTip17 = new ToolTip(this.components);
            this.toolTip18 = new ToolTip(this.components);
            this.toolTip19 = new ToolTip(this.components);
            this.toolTip20 = new ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x1b, 0x27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x61, 0x12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Npc Name";
            this.button1.Location = new Point(0x12b, 0x11c);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x6d, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.Location = new Point(0x8f, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x77, 20);
            this.textBox1.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x1b, 0x52);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5d, 0x12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Npc Entry";
            this.textBox2.Location = new Point(0x8f, 0x53);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x77, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextAlign = HorizontalAlignment.Center;
            this.textBox3.Location = new Point(0x4e, 0xfb);
            this.textBox3.MaxLength = 5;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(100, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.TextAlign = HorizontalAlignment.Center;
            this.textBox4.Location = new Point(0x4e, 0x25);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new Size(100, 0xce);
            this.textBox4.TabIndex = 6;
            this.textBox4.TextAlign = HorizontalAlignment.Center;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x57, 0x10);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x4b, 0x12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Spell ID";
            this.textBox5.Location = new Point(0xe3, 0x25);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new Size(0x2c, 0xce);
            this.textBox5.TabIndex = 8;
            this.textBox5.TextAlign = HorizontalAlignment.Center;
            this.textBox6.Location = new Point(0xe3, 0xf9);
            this.textBox6.MaxLength = 3;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Size(0x2c, 20);
            this.textBox6.TabIndex = 9;
            this.textBox6.TextAlign = HorizontalAlignment.Center;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0xe0, 15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x7c, 0x12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Casted Every";
            this.textBox7.Location = new Point(0x12b, 0x24);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new Size(0x2c, 0xce);
            this.textBox7.TabIndex = 11;
            this.textBox7.TextAlign = HorizontalAlignment.Center;
            this.textBox8.Location = new Point(0x12b, 0xf9);
            this.textBox8.MaxLength = 3;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Size(0x2c, 20);
            this.textBox8.TabIndex = 12;
            this.textBox8.TextAlign = HorizontalAlignment.Center;
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x115, 0xfb);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x10, 0x12);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "Main Tank", "Self", "Random" });
            this.comboBox1.Location = new Point(0x17e, 0xf8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x79, 0x15);
            this.comboBox1.TabIndex = 14;
            this.textBox9.Location = new Point(0x17e, 0x24);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new Size(0x77, 0xce);
            this.textBox9.TabIndex = 15;
            this.textBox9.TextAlign = HorizontalAlignment.Center;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(0x196, 15);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x44, 0x12);
            this.label6.TabIndex = 0x10;
            this.label6.Text = "Target";
            this.textBox13.Location = new Point(0x2a, 0x44);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new Size(0x2c, 0x71);
            this.textBox13.TabIndex = 0x17;
            this.textBox13.TextAlign = HorizontalAlignment.Center;
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(0x15, 0x2f);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x58, 0x12);
            this.label9.TabIndex = 0x18;
            this.label9.Text = "Phase ID";
            this.textBox14.Location = new Point(0x73, 0x45);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new Size(0x79, 0x71);
            this.textBox14.TabIndex = 0x19;
            this.textBox14.TextAlign = HorizontalAlignment.Center;
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] { "Health", "Timer" });
            this.comboBox3.Location = new Point(0x73, 190);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(0x79, 0x15);
            this.comboBox3.TabIndex = 0x1b;
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label10.Location = new Point(0x81, 0x30);
            this.label10.Name = "label10";
            this.label10.Size = new Size(90, 0x12);
            this.label10.TabIndex = 0x1c;
            this.label10.Text = "Condition";
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(0xf2, 0x2f);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x8b, 0x12);
            this.label11.TabIndex = 0x1d;
            this.label11.Text = "Timer/Percent";
            this.textBox15.Location = new Point(0x119, 0x44);
            this.textBox15.Multiline = true;
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new Size(0x2c, 0x71);
            this.textBox15.TabIndex = 30;
            this.textBox15.TextAlign = HorizontalAlignment.Center;
            this.textBox16.Location = new Point(0x119, 190);
            this.textBox16.MaxLength = 3;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Size(0x2c, 20);
            this.textBox16.TabIndex = 0x1f;
            this.textBox16.TextAlign = HorizontalAlignment.Center;
            this.textBox17.Location = new Point(0x222, 0x24);
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new Size(0x2c, 0xce);
            this.textBox17.TabIndex = 0x20;
            this.textBox17.TextAlign = HorizontalAlignment.Center;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x214, 15);
            this.label12.Name = "label12";
            this.label12.Size = new Size(80, 0x12);
            this.label12.TabIndex = 0x22;
            this.label12.Text = "Phase #";
            this.button2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button2.Location = new Point(0x12b, 0xf8);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x6d, 0x17);
            this.button2.TabIndex = 0x23;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.textBox18.Location = new Point(0x183, 0x44);
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new Size(0x77, 0x71);
            this.textBox18.TabIndex = 0x24;
            this.textBox18.TextAlign = HorizontalAlignment.Center;
            this.textBox18.WordWrap = false;
            this.label13.AutoSize = true;
            this.label13.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label13.Location = new Point(0x1a5, 0x2f);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x31, 0x12);
            this.label13.TabIndex = 0x25;
            this.label13.Text = "Text";
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label14.Location = new Point(0x22c, 0x30);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x62, 0x12);
            this.label14.TabIndex = 0x26;
            this.label14.Text = "Chat Type";
            this.textBox19.Location = new Point(0x183, 0xbd);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Size(0x77, 20);
            this.textBox19.TabIndex = 0x27;
            this.textBox20.Location = new Point(0x220, 0x44);
            this.textBox20.Multiline = true;
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new Size(0x79, 0x71);
            this.textBox20.TabIndex = 40;
            this.textBox20.TextAlign = HorizontalAlignment.Center;
            this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] { "Emote", "Say", "Yell" });
            this.comboBox5.Location = new Point(0x220, 0xbd);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new Size(0x79, 0x15);
            this.comboBox5.TabIndex = 0x29;
            this.comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] { "True", "False" });
            this.comboBox6.Location = new Point(0x8f, 130);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new Size(0x54, 0x15);
            this.comboBox6.TabIndex = 0x2a;
            this.label15.AutoSize = true;
            this.label15.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label15.Location = new Point(30, 0x81);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x5e, 0x12);
            this.label15.TabIndex = 0x2b;
            this.label15.Text = "Can Move";
            this.textBox21.Location = new Point(0x222, 0xf8);
            this.textBox21.MaxLength = 3;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Size(0x2c, 20);
            this.textBox21.TabIndex = 0x2c;
            this.textBox21.TextAlign = HorizontalAlignment.Center;
            this.label16.AutoSize = true;
            this.label16.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label16.Location = new Point(0x4b, 0x88);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x3d, 0x12);
            this.label16.TabIndex = 0x2d;
            this.label16.Text = "Aggro";
            this.label17.AutoSize = true;
            this.label17.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label17.Location = new Point(0x15, 0xac);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x73, 0x12);
            this.label17.TabIndex = 0x2e;
            this.label17.Text = "Killed Player";
            this.label18.AutoSize = true;
            this.label18.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label18.Location = new Point(0x4b, 0xd0);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x3d, 0x12);
            this.label18.TabIndex = 0x2f;
            this.label18.Text = "Death";
            this.label19.AutoSize = true;
            this.label19.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label19.Location = new Point(0x15, 0x65);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x47, 0x12);
            this.label19.TabIndex = 0x30;
            this.label19.Text = "Enrage";
            this.label20.AutoSize = true;
            this.label20.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label20.Location = new Point(0xab, 0x4c);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x4b, 0x12);
            this.label20.TabIndex = 0x31;
            this.label20.Text = "Spell ID";
            this.textBox22.Location = new Point(0x9e, 0x66);
            this.textBox22.MaxLength = 5;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Size(100, 20);
            this.textBox22.TabIndex = 50;
            this.textBox22.TextAlign = HorizontalAlignment.Center;
            this.textBox23.Location = new Point(0x9e, 0x89);
            this.textBox23.MaxLength = 5;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Size(100, 20);
            this.textBox23.TabIndex = 0x33;
            this.textBox23.TextAlign = HorizontalAlignment.Center;
            this.textBox24.Location = new Point(0x9e, 0xad);
            this.textBox24.MaxLength = 5;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Size(100, 20);
            this.textBox24.TabIndex = 0x34;
            this.textBox24.TextAlign = HorizontalAlignment.Center;
            this.textBox25.Location = new Point(0x9e, 0xd1);
            this.textBox25.MaxLength = 5;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Size(100, 20);
            this.textBox25.TabIndex = 0x35;
            this.textBox25.TextAlign = HorizontalAlignment.Center;
            this.label21.AutoSize = true;
            this.label21.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label21.Location = new Point(0x12b, 0x4c);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x44, 0x12);
            this.label21.TabIndex = 0x36;
            this.label21.Text = "Target";
            this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] { "Main Tank", "Self", "Random" });
            this.comboBox4.Location = new Point(0x112, 0x66);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new Size(0x79, 0x15);
            this.comboBox4.TabIndex = 0x37;
            this.comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] { "Main Tank", "Self", "Random" });
            this.comboBox7.Location = new Point(0x112, 0x89);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new Size(0x79, 0x15);
            this.comboBox7.TabIndex = 0x38;
            this.comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] { "Main Tank", "Self", "Random" });
            this.comboBox8.Location = new Point(0x112, 0xad);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new Size(0x79, 0x15);
            this.comboBox8.TabIndex = 0x39;
            this.comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Items.AddRange(new object[] { "Main Tank", "Self", "Random" });
            this.comboBox9.Location = new Point(0x112, 0xd1);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new Size(0x79, 0x15);
            this.comboBox9.TabIndex = 0x3a;
            this.label22.AutoSize = true;
            this.label22.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label22.Location = new Point(550, 0x4c);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x62, 0x12);
            this.label22.TabIndex = 0x3b;
            this.label22.Text = "Chat Type";
            this.comboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Items.AddRange(new object[] { "Emote", "Say", "Yell" });
            this.comboBox10.Location = new Point(0x218, 0x66);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new Size(0x79, 0x15);
            this.comboBox10.TabIndex = 60;
            this.comboBox11.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] { "Emote", "Say", "Yell" });
            this.comboBox11.Location = new Point(0x218, 0x8a);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new Size(0x79, 0x15);
            this.comboBox11.TabIndex = 0x3d;
            this.comboBox12.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Items.AddRange(new object[] { "Emote", "Say", "Yell" });
            this.comboBox12.Location = new Point(0x218, 0xae);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new Size(0x79, 0x15);
            this.comboBox12.TabIndex = 0x3e;
            this.comboBox13.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Items.AddRange(new object[] { "Emote", "Say", "Yell" });
            this.comboBox13.Location = new Point(0x218, 210);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new Size(0x79, 0x15);
            this.comboBox13.TabIndex = 0x3f;
            this.textBox26.Location = new Point(100, 0x66);
            this.textBox26.MaxLength = 2;
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Size(0x2c, 20);
            this.textBox26.TabIndex = 0x40;
            this.textBox26.TextAlign = HorizontalAlignment.Center;
            this.label23.AutoSize = true;
            this.label23.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label23.Location = new Point(0x6c, 0x51);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x1c, 0x12);
            this.label23.TabIndex = 0x41;
            this.label23.Text = "%";
            this.button3.Location = new Point(0x142, 0x1be);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x6d, 0x22);
            this.button3.TabIndex = 0x42;
            this.button3.Text = "Create!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.label24.AutoSize = true;
            this.label24.Font = new Font("Segoe Print", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label24.Location = new Point(0x256, 0x1c4);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x6d, 0x1c);
            this.label24.TabIndex = 0x43;
            this.label24.Text = "By Pharcide";
            this.label25.AutoSize = true;
            this.label25.Font = new Font("Segoe Print", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label25.Location = new Point(0x27, 0x1c4);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x69, 0x1c);
            this.label25.TabIndex = 0x44;
            this.label25.Text = "Version 2.2";
            this.label26.AutoSize = true;
            this.label26.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label26.Location = new Point(0x1ba, 0x4d);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0x31, 0x12);
            this.label26.TabIndex = 0x45;
            this.label26.Text = "Text";
            this.textBox27.Location = new Point(0x198, 0x67);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Size(0x77, 20);
            this.textBox27.TabIndex = 70;
            this.textBox28.Location = new Point(0x198, 0x8a);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Size(0x77, 20);
            this.textBox28.TabIndex = 0x47;
            this.textBox29.Location = new Point(0x198, 0xae);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Size(0x77, 20);
            this.textBox29.TabIndex = 0x48;
            this.textBox30.Location = new Point(0x198, 210);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Size(0x77, 20);
            this.textBox30.TabIndex = 0x49;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new Point(0x10, 0x48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x2c4, 0x153);
            this.tabControl1.TabIndex = 0x4a;
            this.tabPage1.BackColor = Color.Transparent;
            this.tabPage1.Controls.Add(this.textBox13);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.textBox14);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.textBox15);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.textBox18);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.textBox20);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.textBox16);
            this.tabPage1.Controls.Add(this.textBox19);
            this.tabPage1.Controls.Add(this.comboBox5);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPage1.Location = new Point(4, 0x16);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(700, 0x139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Phase";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage2.BackColor = Color.Transparent;
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.textBox9);
            this.tabPage2.Controls.Add(this.textBox17);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.textBox8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.textBox21);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPage2.Location = new Point(4, 0x16);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(700, 0x139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Spell";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.textBox30);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.textBox29);
            this.tabPage3.Controls.Add(this.comboBox13);
            this.tabPage3.Controls.Add(this.textBox26);
            this.tabPage3.Controls.Add(this.textBox28);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.comboBox9);
            this.tabPage3.Controls.Add(this.comboBox12);
            this.tabPage3.Controls.Add(this.textBox25);
            this.tabPage3.Controls.Add(this.textBox27);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.textBox22);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.comboBox11);
            this.tabPage3.Controls.Add(this.comboBox8);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.comboBox4);
            this.tabPage3.Controls.Add(this.textBox24);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.comboBox10);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.comboBox7);
            this.tabPage3.Controls.Add(this.textBox23);
            this.tabPage3.Location = new Point(4, 0x16);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new Size(700, 0x139);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Events";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.textBox12);
            this.tabPage4.Controls.Add(this.comboBox14);
            this.tabPage4.Controls.Add(this.label29);
            this.tabPage4.Controls.Add(this.textBox11);
            this.tabPage4.Controls.Add(this.label28);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.textBox10);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.comboBox2);
            this.tabPage4.Controls.Add(this.comboBox6);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.ForeColor = SystemColors.ControlText;
            this.tabPage4.Location = new Point(4, 0x16);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new Size(700, 0x139);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Misc";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.button4.Location = new Point(0x1b1, 0xef);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x6d, 0x17);
            this.button4.TabIndex = 0x37;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click_1);
            this.textBox12.Location = new Point(350, 190);
            this.textBox12.MaxLength = 5;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Size(0x77, 20);
            this.textBox12.TabIndex = 0x36;
            this.textBox12.TextAlign = HorizontalAlignment.Center;
            this.comboBox14.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Items.AddRange(new object[] { "Arcane", "Shadow", "Frost", "Fire", "Nature", "Holy", "Physical" });
            this.comboBox14.Location = new Point(0x200, 0xbd);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new Size(0x79, 0x15);
            this.comboBox14.TabIndex = 0x35;
            this.label29.AutoSize = true;
            this.label29.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label29.Location = new Point(0x1fd, 0x31);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x6f, 0x12);
            this.label29.TabIndex = 0x34;
            this.label29.Text = "Spell School";
            this.textBox11.Location = new Point(0x200, 70);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new Size(0x79, 0x71);
            this.textBox11.TabIndex = 0x33;
            this.textBox11.TextAlign = HorizontalAlignment.Center;
            this.label28.AutoSize = true;
            this.label28.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label28.Location = new Point(0x171, 0x31);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x4b, 0x12);
            this.label28.TabIndex = 50;
            this.label28.Text = "Spell ID";
            this.label27.AutoSize = true;
            this.label27.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label27.Location = new Point(430, 13);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x97, 0x12);
            this.label27.TabIndex = 0x2f;
            this.label27.Text = "Spell Immunities";
            this.textBox10.Location = new Point(0x15c, 70);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new Size(0x79, 0x71);
            this.textBox10.TabIndex = 0x2e;
            this.textBox10.TextAlign = HorizontalAlignment.Center;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x15, 0xa5);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x63, 0x12);
            this.label8.TabIndex = 0x2d;
            this.label8.Text = "Core Type";
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] { "Trinity", "Mangos" });
            this.comboBox2.Location = new Point(0x8f, 0xa6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(0x54, 0x15);
            this.comboBox2.TabIndex = 0x2c;
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Times New Roman", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label7.Location = new Point(0x94, 9);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x1d7, 0x24);
            this.label7.TabIndex = 0x4b;
            this.label7.Text = "Trinity-Mangos Script Generator";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.ControlLight;
            base.ClientSize = new Size(0x2ea, 0x1ee);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.label25);
            base.Controls.Add(this.label24);
            base.Controls.Add(this.button3);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Name = "Form1";
            this.Text = "Trinity-Mangos Script Generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

