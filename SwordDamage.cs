using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamageWpfApp
{
    internal class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        /// <summary>
        /// Contém o dano calculado
        /// </summary>
        public int Damage { get; private set; }

        private int roll;

        /// <summary>
        /// Define com set ou obtém com get o dado 3d6
        /// </summary>
        public int Roll
        {
            get { return roll; }

            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        private bool flaming;
        /// <summary>
        /// True se a espada está em chamas, false do contrário
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }

            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        private bool magic;
        /// <summary>
        /// True se a espada é mágica, false do contrário
        /// </summary>
        public bool Magic
        {
            get { return magic; }

            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// O construtor calcula o dano com base nos valores Magic
        /// e Flaming padrão, em um dado 3d6 inicial
        /// </summary>
        /// <param name="startingRoll">Dado inicial 3d6</param>
        public SwordDamage(int startingRoll)
        {
            Roll = startingRoll;
        }

        /// <summary>
        /// Calcula o dano com base nas propriedades atuais
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultipler = 1M;
            if (Magic) magicMultipler = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultipler) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }

    }
}
