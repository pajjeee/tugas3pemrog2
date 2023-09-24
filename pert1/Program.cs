using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_1
{
    public abstract  class Hero
    {
        private int ability; // Atribut kemampuan hero
        private int damage; // Atribut kerusakan

        // Properti untuk mengakses atribut ini encasulapsion

        public int Ability
        {
            get { return ability; }
            protected set { ability = value; }
        }
        public int Damage
        {
            get { return damage; }
            protected set { damage = value; }
        }
        public Hero(int ability, int damage)
        {
            this.ability = ability;
            this.damage = damage;

        }


        // Metode Untuk kerusakan yang boleh di overide dan boleh tidak 
        public virtual void Damage()
        {
            Console.WriteLine("Kerusakan yang di terima lawan");
        }
        public virtual void minAbility()
        {
            this.ability -= 20;
            Console.WriteLine("Kemampuan hero melemah {0}", Ability);
        }

        //  abstrak untuk bergerak beda setiap child class nya
        //ini wajib di implementasi di class turunan nya 
        public abstract void Durability();
    }

    // Kelas turunan Karakter Lawan
    public class Lawan : Hero
    {
        public Lawan(int ability, int damage) : base(ability, damage)
        {

        }

        // Mengimplementasikan ulang metode Attack dan minAbility 
        public override void Damage()
        {
            Console.WriteLine("kerusakan yag diterima hero");
        }

        public override void Durability()
        {
            this.Durability -= 40;// ubah min menjadi -40 
            Console.WriteLine("Ketahanan lawan melemah menjadi -40 jadi tinggal{0}", Ability);

        }

        public override void minAbility()
        {
            this.Ability -= 40;// ubah min menjadi  -40
            Console.WriteLine("Ketahanan lawan melemah menjadi -40 jadi tinggal{0}", Ability);
        }

        // Implementasi metode Durability
        public override void Durability()
        {
            Console.WriteLine("ketahanan lawan melemah");
        }
    }

    // Kelas turunan carakter skin
    public class Skin : Hero
    {
        public String name;
        public Skin(int ability, int damage, String name) : base(ability, damage)
        {
            this.name = name;
        }

        public override void Durability()
        {
            throw new NotImplementedException();
        }

        // ini memang sengaja tidak mengoveride damage dan minAbility 

        // Implementasi metode Move
        public override void Durability()
        {
            Console.WriteLine("hero {0} bergerak ke musuh", this.name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lawan lawan = new Lawan(5,5);
            Skin summer = new Skin(12, 8, "Summer");
            lawan.Durability();
            lawan.Damage();
            summer.minAbility();
            summer.Durability();
            summer.Damage();
            lawan.minAbility();
        }
    }
}
