namespace Trinity_Script_Generator_2
{
    using System;
    using System.Collections.Generic;

    internal class Phase
    {
        private int arguement;
        private string chatType;
        private string condition;
        private int id;
        private List<Spell> spells = new List<Spell>();
        private string text;

        public void AddSpell(int spellId, int castTimeLow, int castTimeHigh, string target)
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
            item.Phase = this.id;
            this.spells.Add(item);
        }

        public int Arguement
        {
            get
            {
                return this.arguement;
            }
            set
            {
                this.arguement = value;
            }
        }

        public string ChatType
        {
            get
            {
                return this.chatType;
            }
            set
            {
                this.chatType = value;
            }
        }

        public string Condition
        {
            get
            {
                return this.condition;
            }
            set
            {
                this.condition = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public List<Spell> Spells
        {
            get
            {
                return this.spells;
            }
            set
            {
                this.spells = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
    }
}

