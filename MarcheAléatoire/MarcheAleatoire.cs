using System;
namespace MarcheAléatoire
{
    public class MarcheAleatoire
    {
        private int nbrFoot;
        private char type;

        public MarcheAleatoire(int nbrFoot, char type)
        {
            this.nbrFoot = nbrFoot;
            if (type.Equals('C') || type.Equals('S') || type.Equals('U'))
            {
                this.type = type;
            }
            else
            {
                this.type = 'C';
            }
        }
    }
}
