/* ScriptData
SDName: ironaya
SD%Complete: xx%
SDComment: 
SDCategory: 
EndScriptData */

// UPDATE `creature_template` SET ScriptName='ironaya' WHERE `entry`=7228;

#include "ScriptPCH.h"

enum Texts
{

};

enum Spells
{

};

class ironaya : public CreatureScript
{
    public:

        CreatureAI* GetAI(Creature* pCreature) const
        {
            return new ironayaAI(pCreature);
        }

        struct ironayaAI : public ScriptedAI
        {
            ironayaAI(Creature* pCreature) : ScriptedAI(pCreature)
            {
                pInstance = pCreature->GetInstanceScript();
                SetCombatMovement(true);
            }

            std::list<uint64> SummonList;

            InstanceScript *pInstance;

            uint32 Spell1Timer;
            uint32 Spell1Phase1Timer;
            uint32 Spell1Phase2Timer;
            uint32 Phase;


            void EnterCombat(Unit *who)
            {
                me->MonsterYell("None may steal the secrets of the Makers!", LANG_UNIVERSAL, NULL);
            }

            void KilledUnit(Unit* victim)
            {
            }

            void JustDied(Unit* Killer)
            {
            }

            void Reset()
            {
                RemoveSummons();
                Spell1Timer = 3000+rand()%1000;
                Spell1phase1Timer = 0+rand()%1000;
                Spell1Phase2Timer = 0+rand()%1000;
                Phase = 0;
            }

            void RemoveSummons()
            {
                if (SummonList.empty())
                    return;

                for (std::list<uint64>::const_iterator itr = SummonList.begin(); itr != SummonList.end(); ++itr)
                {
                    if (Creature* pTemp = Unit::GetCreature(*me, *itr))
                        if (pTemp)
                            pTemp->DisappearAndDie();
                }
                SummonList.clear();
            }

            void JustSummoned(Creature* pSummon)
            {
                SummonList.push_back(pSummon->GetGUID());
            }

            void UpdateAI(const uint32 diff)
            {
                if (!UpdateVictim())
                    return;

                if (Phase == 1)
                {
                    if (Spell1Phase1Timer <= diff)
                    {
                        DoCast(me->getVictim(), 10101);
                        Spell1Phase1Timer = 0+rand()%1000;
                    } else Spell1Phase1Timer -= diff;
                }

                if (Phase == 2)
                {
                    if (Spell1Phase2Timer <= diff)
                    {
                        DoCast(me, 11876);
                        Spell1Phase2Timer = 0+rand()%1000;
                    } else Spell1Phase2Timer -= diff;
                }

                if (Spell1Timer <= diff)
                {
                    DoCast(me, 8374);
                    Spell1Timer = 3000+rand()%1000;
                } else Spell1Timer -= diff;

                DoMeleeAttackIfReady();
            }
        }
};

void AddSC_ironaya()
{
    new ironaya();
}