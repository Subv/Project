namespace CataProject_Script_Generator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public partial class Form1 : Form
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
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private ComboBox comboBox7;
        private ComboBox comboBox8;
        private ComboBox comboBox9;
        //private IContainer components;
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
        private TabPage tabPage5;
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
            string str = "Spell";
            string str2 = "Phase";
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Npc name cannot be empty!");
            }
            else if (this.textBox2.Text == "")
            {
                MessageBox.Show("Npc entry cannot be empty!");
            }
            else
            {
                string str3 = "trinity";
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
                        List<Spell>.Enumerator enumerator;
                        string str6;
                        string str7;
                        string str8;
                        string str9;
                        string str10;
                        string str11;
                        AddText(stream, "/* ScriptData");
                        AddText(stream, "\r\nSDName: " + this.textBox1.Text);
                        AddText(stream, "\r\nSD%Complete: xx%");
                        AddText(stream, "\r\nSDComment: ");
                        AddText(stream, "\r\nSDCategory: ");
                        AddText(stream, "\r\nEndScriptData */");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n// UPDATE `creature_template` SET ScriptName='" + this.textBox1.Text + "' WHERE `entry`=" + num6.ToString() + ";");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n#include \"ScriptPCH.h\"");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\nenum Texts");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n};");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\nenum Spells");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n};");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\nclass " + this.textBox1.Text + " : public CreatureScript");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n    public:");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n        CreatureAI* GetAI(Creature* pCreature) const");
                        AddText(stream, "\r\n        {");
                        AddText(stream, "\r\n            return new " + this.textBox1.Text + "AI(pCreature);");
                        AddText(stream, "\r\n        }");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n        struct " + this.textBox1.Text + "AI : public ScriptedAI");
                        AddText(stream, "\r\n        {");
                        AddText(stream, "\r\n            " + this.textBox1.Text + "AI(Creature* pCreature) : ScriptedAI(pCreature)");
                        AddText(stream, "\r\n            {");
                        AddText(stream, "\r\n                pInstance = pCreature->GetInstanceScript();");
                        AddText(stream, "\r\n                SetCombatMovement(" + this.comboBox6.SelectedItem.ToString().ToLower() + ");");
                        AddText(stream, "\r\n            }");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n            std::list<uint64> SummonList;");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n            InstanceScript *pInstance;");
                        AddText(stream, "\r\n");
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
                                    AddText(stream, "\r\n            uint32 " + str + "Timer;");
                                    str = "Spell";
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
                                            AddText(stream, "\r\n            uint32 " + str + "" + str2 + "Timer;");
                                            str = "Spell";
                                            str2 = "Phase";
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
                                        AddText(stream, "\r\n            uint32 " + str2 + "Percent;");
                                    }
                                }
                                goto Label_093D;
                            Label_0925:
                                AddText(stream, "\r\n            uint32 " + str2 + "Timer;");
                            Label_093D:
                                str2 = "phase";
                            }
                            AddText(stream, "\r\n            uint32 Phase;\r\n");
                        }
                        if (this.textBox26.Text != "")
                        {
                            AddText(stream, "\r\n            bool Enraged;\r\n");
                        }
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n            void EnterCombat(Unit *who)");
                        AddText(stream, "\r\n            {");
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
                                AddText(stream, "\r\n                me->MonsterYell(\"" + this.textBox28.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_0A71;
                    Label_0A2D:
                        AddText(stream, "\r\n                me->MonsterSay(\"" + this.textBox28.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_0A71;
                    Label_0A50:
                        AddText(stream, "\r\n         me->MonsterTextEmote(+ \"" + this.textBox28.Text + "\", NULL, false);");
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
                                AddText(stream, "\r\n                DoCast(me, " + num3.ToString() + ");");
                            }
                        }
                        goto Label_0B1B;
                    Label_0ADF:
                        AddText(stream, "\r\n                DoCast(me->getVictim(), " + num3.ToString() + ");");
                        goto Label_0B1B;
                    Label_0AFE:
                        AddText(stream, "\r\n                DoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num3.ToString() + ");");
                    Label_0B1B:
                        AddText(stream, "\r\n            }");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n            void KilledUnit(Unit* victim)");
                        AddText(stream, "\r\n            {");
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
                                AddText(stream, "\r\n               me->MonsterYell(\"" + this.textBox29.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_0C09;
                    Label_0BC5:
                        AddText(stream, "\r\n                me->MonsterSay(\"" + this.textBox29.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_0C09;
                    Label_0BE8:
                        AddText(stream, "\r\n                me->MonsterTextEmote(\"" + this.textBox29.Text + "\", NULL, false);");
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
                                AddText(stream, "\r\n                DoCast(me, " + num4.ToString() + ");");
                            }
                        }
                        goto Label_0CB3;
                    Label_0C77:
                        AddText(stream, "\r\n                DoCast(me->getVictim(), " + num4.ToString() + ");");
                        goto Label_0CB3;
                    Label_0C96:
                        AddText(stream, "\r\n                DoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num4.ToString() + ");");
                    Label_0CB3:
                        AddText(stream, "\r\n            }\r\n");
                        AddText(stream, "\r\n            void JustDied(Unit* Killer)");
                        AddText(stream, "\r\n            {");
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
                                AddText(stream, "\r\n                me->MonsterYell(\"" + this.textBox30.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_0DA1;
                    Label_0D5D:
                        AddText(stream, "\r\n                me->MonsterSay(\"" + this.textBox30.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_0DA1;
                    Label_0D80:
                        AddText(stream, "\r\n                me->MonsterTextEmote(\"" + this.textBox30.Text + "\", NULL, false);");
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
                                AddText(stream, "\r\n                DoCast(me, " + num5.ToString() + ");");
                            }
                        }
                        goto Label_0E4C;
                    Label_0E10:
                        AddText(stream, "\r\n                DoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num5.ToString() + ");");
                        goto Label_0E4C;
                    Label_0E2F:
                        AddText(stream, "\r\n                DoCast(me->getVictim(), " + num5.ToString() + ");");
                    Label_0E4C:
                        AddText(stream, "\r\n            }\r\n");
                        AddText(stream, "\r\n            void Reset()");
                        AddText(stream, "\r\n            {");
                        AddText(stream, "\r\n                RemoveSummons();");
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            foreach (Spell spell in this.nonPhasedSpells)
                            {
                                num7++;
                                str = str + num7.ToString();
                                if (spell.CastTimeHigh != 0)
                                {
                                    AddText(stream, "\r\n                " + str + "Timer = " + spell.CastTimeLow.ToString() + "+rand()%" + spell.CastTimeHigh.ToString() + ";");
                                }
                                else
                                {
                                    AddText(stream, "\r\n                " + str + "Timer = " + spell.CastTimeLow.ToString() + ";");
                                }
                                str = "Spell";
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
                                            AddText(stream, "\r\n                " + str + "" + str2 + "Timer = " + spell2.CastTimeLow.ToString() + "+rand()%" + spell2.CastTimeHigh.ToString() + ";");
                                        }
                                        else
                                        {
                                            AddText(stream, "\r\n                " + str + "" + str2 + "Timer = " + spell2.CastTimeLow.ToString() + ";");
                                        }
                                        str = "Spell";
                                        str2 = "Phase";
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
                                        strArray[0] = "\r\n                ";
                                        strArray[1] = str2;
                                        strArray[2] = "Percent = ";
                                        int arguement = phase4.Arguement;
                                        strArray[3] = arguement.ToString();
                                        strArray[4] = ";";
                                        AddText(stream, string.Concat(strArray));
                                    }
                                }
                                goto Label_1252;
                            Label_11F7:
                                phase4.Arguement *= 0x3e8;
                                AddText(stream, string.Concat(new object[] { "\r\n                ", str2, "Timer = ", phase4.Arguement, ";" }));
                            Label_1252:
                                str2 = "Phase";
                            }
                            AddText(stream, "\r\n                Phase = 0;");
                            if (this.spellImmunities.Count > 0)
                            {
                                foreach (SpellImmunity immunity in this.spellImmunities)
                                {
                                    switch (immunity.School)
                                    {
                                        case "frost":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_FROST, true);");
                                            break;

                                        case "fire":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_FIRE, true);");
                                            break;

                                        case "nature":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_NATURE, true);");
                                            break;

                                        case "shadow":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_SHADOW, true);");
                                            break;

                                        case "arcane":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_ARCANE, true);");
                                            break;

                                        case "holy":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_HOLY, true);");
                                            break;

                                        case "physical":
                                            AddText(stream, "\r\n                me->ApplySpellImmune(0, IMMUNITY_DAMAGE, SPELL_SCHOOL_MASK_NORMAL, true);");
                                            break;
                                    }
                                    if (immunity.SpellId != 0)
                                    {
                                        AddText(stream, "\r\n                me->ApplySpellImmune(" + immunity.SpellId + ", IMMUNITY_DAMAGE, 0, true);");
                                    }
                                }
                            }
                            if (result != 0)
                            {
                                AddText(stream, "\r\n                Enraged = false;");
                            }
                        }
                        AddText(stream, "\r\n            }\r\n");
                        AddText(stream, "\r\n            void RemoveSummons()");
                        AddText(stream, "\r\n            {");
                        AddText(stream, "\r\n                if (SummonList.empty())");
                        AddText(stream, "\r\n                    return;");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n                for (std::list<uint64>::const_iterator itr = SummonList.begin(); itr != SummonList.end(); ++itr)");
                        AddText(stream, "\r\n                {");
                        AddText(stream, "\r\n                    if (Creature* pTemp = Unit::GetCreature(*me, *itr))");
                        AddText(stream, "\r\n                        if (pTemp)");
                        AddText(stream, "\r\n                            pTemp->DisappearAndDie();");
                        AddText(stream, "\r\n                }");
                        AddText(stream, "\r\n                SummonList.clear();");
                        AddText(stream, "\r\n            }");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n            void JustSummoned(Creature* pSummon)");
                        AddText(stream, "\r\n            {");
                        AddText(stream, "\r\n                SummonList.push_back(pSummon->GetGUID());");
                        AddText(stream, "\r\n            }");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\n            void UpdateAI(const uint32 diff)");
                        AddText(stream, "\r\n            {");
                        AddText(stream, "\r\n                if (!UpdateVictim())");
                        AddText(stream, "\r\n                    return;\r\n");
                        if (result == 0)
                        {
                            goto Label_160C;
                        }
                        AddText(stream, "\r\n                if ((me->GetHealth() * 100 / me->GetMaxHealth() <= " + result + ") && !Enraged)");
                        AddText(stream, "\r\n                {");
                        AddText(stream, "\r\n                    Enraged = true;");
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
                                AddText(stream, "\r\n                    DoCast(me, " + num2.ToString() + ");");
                            }
                        }
                        goto Label_1536;
                    Label_14FA:
                        AddText(stream, "\r\n                    DoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + num2.ToString() + ");");
                        goto Label_1536;
                    Label_1519:
                        AddText(stream, "\r\n                    DoCastVictim(" + num2.ToString() + ");");
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
                                AddText(stream, "\r\n                    me->MonsterYell(\"" + this.textBox27.Text + "\", LANG_UNIVERSAL, NULL);");
                            }
                        }
                        goto Label_1600;
                    Label_15BC:
                        AddText(stream, "\r\n                    me->MonsterSay(\"" + this.textBox27.Text + "\", LANG_UNIVERSAL, NULL);");
                        goto Label_1600;
                    Label_15DF:
                        AddText(stream, "\r\n                    me->MonsterTextEmote(\"" + this.textBox27.Text + "\", NULL, false);");
                    Label_1600:
                        AddText(stream, "\r\n                }\r\n");
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
                                AddText(stream, string.Concat(new object[] { "\r\n                if ((me->GetHealth() * 100 / me->GetMaxHealth() <= ", phase5.Arguement, ") && Phase == ", num9.ToString(), ")" }));
                                AddText(stream, "\r\n                {");
                                AddText(stream, "\r\n                    Phase = " + num7.ToString() + ";");
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
                                        AddText(stream, "\r\n                    me->MonsterYell(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                    }
                                }
                                goto Label_17B2;
                            Label_1776:
                                AddText(stream, "\r\n                    me->MonsterSay(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                goto Label_17B2;
                            Label_1795:
                                AddText(stream, "\r\n                    me->MonsterTextEmote(\"" + phase5.Text + "\", NULL, false);");
                            Label_17B2:
                                AddText(stream, "\r\n                }\r\n");
                                goto Label_190E;
                            Label_17C3:
                                AddText(stream, "\r\n                if (Phase == " + num9.ToString() + ")");
                                AddText(stream, "\r\n                {");
                                AddText(stream, "\r\n                    if (" + str2 + "Timer <= diff)");
                                AddText(stream, "\r\n                    {");
                                AddText(stream, "\r\n                        Phase = " + num7.ToString() + ";");
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
                                        AddText(stream, "\r\n                        me->MonsterYell(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                    }
                                }
                                goto Label_18DE;
                            Label_18A2:
                                AddText(stream, "\r\n                        me->MonsterSay(\"" + phase5.Text + "\", LANG_UNIVERSAL, NULL);");
                                goto Label_18DE;
                            Label_18C1:
                                AddText(stream, "\r\n                        me->MonsterTextEmote(\"" + phase5.Text + "\", NULL, false);");
                            Label_18DE:
                                AddText(stream, "\r\n                    }");
                                AddText(stream, "\r\n                    else " + str2 + "Timer -= diff;");
                                AddText(stream, "\r\n                }\r\n");
                            Label_190E:
                                str2 = "Phase";
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
                                    AddText(stream, "\r\n                if (Phase == " + num8.ToString() + ")");
                                    AddText(stream, "\r\n                {");
                                }
                                while (num8 != phase6.Id);
                                foreach (Spell spell3 in phase6.Spells)
                                {
                                    num7++;
                                    str = str + num7.ToString();
                                    str2 = str2 + num8.ToString();
                                    AddText(stream, "\r\n                    if (" + str + "" + str2 + "Timer <= diff)");
                                    AddText(stream, "\r\n                    {");
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
                                            AddText(stream, "\r\n                        DoCast(me, " + spell3.SpellId + ");");
                                        }
                                    }
                                    goto Label_1ADB;
                                Label_1A95:
                                    AddText(stream, "\r\n                        DoCast(me->getVictim(), " + spell3.SpellId + ");");
                                    goto Label_1ADB;
                                Label_1AB9:
                                    AddText(stream, "\r\n                        DoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + spell3.SpellId + ");");
                                Label_1ADB:
                                    if (spell3.CastTimeHigh != 0)
                                    {
                                        AddText(stream, "\r\n                        " + str + "" + str2 + "Timer = " + spell3.CastTimeLow.ToString() + "+rand()%" + spell3.CastTimeHigh.ToString() + ";");
                                    }
                                    else
                                    {
                                        AddText(stream, "\r\n                        " + str + "" + str2 + "Timer = " + spell3.CastTimeLow.ToString() + ";");
                                    }
                                    AddText(stream, "\r\n                    } else " + str + "" + str2 + "Timer -= diff;");
                                    str = "Spell";
                                    str2 = "Phase";
                                }
                                AddText(stream, "\r\n                }\r\n");
                            }
                        }
                        num7 = 0;
                        if (this.nonPhasedSpells.Count > 0)
                        {
                            foreach (Spell spell4 in this.nonPhasedSpells)
                            {
                                num7++;
                                str = str + num7.ToString();
                                AddText(stream, "\r\n                if (" + str + "Timer <= diff)");
                                AddText(stream, "\r\n                {");
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
                                        AddText(stream, "\r\n                    DoCast(me, " + spell4.SpellId + ");");
                                    }
                                }
                                goto Label_1D4E;
                            Label_1D08:
                                AddText(stream, "\r\n                    DoCast(me->getVictim(), " + spell4.SpellId + ");");
                                goto Label_1D4E;
                            Label_1D2C:
                                AddText(stream, "\r\n                    DoCast(SelectTarget(SELECT_TARGET_RANDOM, 0, 0, true), " + spell4.SpellId + ");");
                            Label_1D4E:
                                if (spell4.CastTimeHigh != 0)
                                {
                                    AddText(stream, "\r\n                    " + str + "Timer = " + spell4.CastTimeLow.ToString() + "+rand()%" + spell4.CastTimeHigh.ToString() + ";");
                                }
                                else
                                {
                                    AddText(stream, "\r\n                    " + str + "Timer = " + spell4.CastTimeLow.ToString() + ";");
                                }
                                AddText(stream, "\r\n                } else " + str + "Timer -= diff;\r\n");
                                str = "spell";
                            }
                        }
                        AddText(stream, "\r\n                DoMeleeAttackIfReady();");
                        AddText(stream, "\r\n            }");
                        AddText(stream, "\r\n        }");
                        AddText(stream, "\r\n};");
                        AddText(stream, "\r\n");
                        AddText(stream, "\r\nvoid AddSC_" + this.textBox1.Text + "()");
                        AddText(stream, "\r\n{");
                        AddText(stream, "\r\n    new " + this.textBox1.Text + "();");
                        AddText(stream, "\r\n}");
                        goto Label_38F9;
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
                    this.comboBox6.SelectedItem = "True";
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

        private Phase FindPhaseById(int id)
        {
            Phase phase = this.phases.Find(pPhase => pPhase.Id == id);
            if (phase == null)
            {
                return null;
            }
            return phase;
        }
    }
}

