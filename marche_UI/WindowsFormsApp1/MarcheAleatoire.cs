using System;
using System.Collections;

namespace WindowsFormsApp1
{
    public class MarcheAleatoire
    {
        private int nbrFoot;
        private char type;
        private Position[] prevPositions;
        private Position actualPos;
        private int positionMax;

        // Constructor
        public MarcheAleatoire(int nbrFoot, char type)
        {
            this.NbrFoot = nbrFoot;
            PrevPositions = new Position[nbrFoot];
            actualPos = new Position();
            positionMax = 0;
            if (type.Equals('C') || type.Equals('S') || type.Equals('U'))
            {
                this.Type = type;
            }
            else
            {
                this.Type = 'C';
            }
        }

        // Getter and Setter
        public int NbrFoot { get => nbrFoot; set => nbrFoot = value; }
        public char Type { get => type; set => type = value; }
        internal Position[] PrevPositions { get => prevPositions; set => prevPositions = value; }
        internal Position ActualPos { get => actualPos; set => actualPos = value; }
        public int PositionMax { get => positionMax; set => positionMax = value; }

        // Other Functions

        public void walk(RandomGenerator generator)
        {
            int dir;
            int value;
            if (Type.Equals('C'))
            {
                for(int i = 0; i < NbrFoot; i++)
                {
                    PrevPositions[i] = new Position(ActualPos);
                    dir = generator.generate(0, 1);
                    value = generator.generate(0, 1);
                    if (value == 0)
                    {
                        value = -1;
                    }
                    ActualPos.setIndex(dir,ActualPos.getIndex(dir) + value);
                    if (Math.Abs(ActualPos.X) > positionMax) positionMax = Math.Abs(ActualPos.X);
                    if (Math.Abs(ActualPos.Y) < positionMax) positionMax = Math.Abs(ActualPos.Y);
                }
                
            }
            else
            {
                if (Type.Equals('S'))
                {
                    for (int i = 0; i < NbrFoot; i++)
                    {
                        if (i != 0)
                        {
                            do
                            {
                                dir = generator.generate(0, 1);
                                value = generator.generate(0, 1);
                                if (value == 0)
                                {
                                    value = -1;
                                }
                            } while (ActualPos.getIndex(dir) + value == PrevPositions[i - 1].getIndex(dir));
                            PrevPositions[i] = new Position(ActualPos); ;
                            ActualPos.setIndex(dir, ActualPos.getIndex(dir) + value);
                            if (Math.Abs(ActualPos.X) > positionMax) positionMax = Math.Abs(ActualPos.X);
                            if (Math.Abs(ActualPos.Y) < positionMax) positionMax = Math.Abs(ActualPos.Y);
                        }
                        else
                        {
                            PrevPositions[i] = new Position(ActualPos); ;
                            dir = generator.generate(0, 1);
                            value = generator.generate(0, 1);
                            if (value == 0)
                            {
                                value = -1;
                            }
                            ActualPos.setIndex(dir, ActualPos.getIndex(dir) + value);
                            if (Math.Abs(ActualPos.X) > positionMax) positionMax = Math.Abs(ActualPos.X);
                            if (Math.Abs(ActualPos.Y) < positionMax) positionMax = Math.Abs(ActualPos.Y);

                        }                        
                    }
                }
                else
                {
                    int i = 0;
                    bool selfavoided;
                    while (i < NbrFoot)
                    {
                        if(i!=0)
                        {
                            
                            do
                            {
                                dir = generator.generate(0, 1);
                                value = generator.generate(0, 1);
                                if (value == 0)
                                {
                                    value = -1;
                                }
                            } while (ActualPos.getIndex(dir) + value == PrevPositions[i - 1].getIndex(dir));
                            PrevPositions[i] = new Position(ActualPos);
                            ActualPos.setIndex(dir, ActualPos.getIndex(dir) + value);
                            if (Math.Abs(ActualPos.X) > positionMax) positionMax = Math.Abs(ActualPos.X);
                            if (Math.Abs(ActualPos.Y) < positionMax) positionMax = Math.Abs(ActualPos.Y);
                            i++;
                            IEnumerator enumerator = PrevPositions.GetEnumerator();
                            selfavoided = true;
                            while (enumerator.MoveNext() && selfavoided)
                            {
                                // Si on retombe sur 1 position deja attribué il faut recommencer depuis le debut(cf article)
                                if (enumerator.Current != null) {
                                    if (enumerator.Current.Equals(ActualPos))
                                    {
                                        selfavoided = false;
                                        PrevPositions = new Position[NbrFoot];
                                        ActualPos = new Position();
                                        positionMax = 0;
                                        i = 0;
                                    }
                                }
                                
                            }
                        }
                        else
                        {
                            PrevPositions[i] = new Position(ActualPos); ;
                            dir = generator.generate(0, 1);
                            value = generator.generate(0, 1);
                            if (value == 0)
                            {
                                value = -1;
                            }
                            ActualPos.setIndex(dir, ActualPos.getIndex(dir) + value);
                            if (Math.Abs(ActualPos.X) > positionMax) positionMax = Math.Abs(ActualPos.X);
                            if (Math.Abs(ActualPos.Y) < positionMax) positionMax = Math.Abs(ActualPos.Y);
                            i++;
                        }
                    }
                }
            }
        }
    }
}
