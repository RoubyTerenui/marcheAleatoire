using System;
using System.Collections;

namespace MarcheAléatoire
{
    public class MarcheAleatoire
    {
        private int nbrFoot;
        private char type;
        private Position[] prevPositions;
        private Position actualPos;

        // Constructor
        public MarcheAleatoire(int nbrFoot, char type)
        {
            this.NbrFoot = nbrFoot;
            PrevPositions = new Position[nbrFoot];
            actualPos = new Position();
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

        // Other Functions

        public char[] walk()
        {
            RandomGenerator generator = new RandomGenerator(13, 1073, 43215, 4294967087, 1403580, 810728);
            char[] path = new char[NbrFoot];
            int dir;
            int value;
            if (Type.Equals('C'))
            {
                for(int i = 0; i < NbrFoot; i++)
                {
                    PrevPositions[i] = ActualPos;
                    dir = generator.generate(0, 1);
                    value = generator.generate(0, 1);
                    if (value == 0)
                    {
                        value = -1;
                    }
                    ActualPos.setIndex(dir,ActualPos.getIndex(dir) + value);
                }
                
            }
            else
            {
                if (Type.Equals('S'))
                {
                    for (int i = 0; i < NbrFoot; i++)
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
                        PrevPositions[i] = ActualPos;
                        ActualPos.setIndex(dir, ActualPos.getIndex(dir) + value);
                        
                    }
                }
                else
                {
                    int i = 0;
                    bool selfavoided;
                    while ( i < NbrFoot)
                        {
                        i++;
                        do
                        {
                            dir = generator.generate(0, 1);
                            value = generator.generate(0, 1);
                            if (value == 0)
                            {
                                value = -1;
                            }
                        } while (ActualPos.getIndex(dir) + value == PrevPositions[i - 1].getIndex(dir));
                        PrevPositions[i] = ActualPos;
                        ActualPos.setIndex(dir, ActualPos.getIndex(dir) + value);
                        IEnumerator enumerator = PrevPositions.GetEnumerator();
                        selfavoided = true;
                        while (enumerator.MoveNext() && selfavoided)
                        {
                            // Si on retombe sur 1 position deja attribué il faut recommencer depuis le debut(cf article)
                            if (enumerator.Current.Equals(ActualPos))
                            {
                                selfavoided = false;
                                PrevPositions = new Position[NbrFoot];
                                ActualPos = new Position();
                                i = 0;
                            }
                        }
                    }
                }
            }
            return (path);
        }
    }
}
