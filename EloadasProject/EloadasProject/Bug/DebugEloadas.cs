using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProject.Bug
{
    class DebugEloadas
    {
        [TestFixture]
        class EloadasDebug
        {
            Eloadas eloadas;
            [SetUp]
            public void SetUp()
            {
                eloadas = new Eloadas(6, 14);
            }
            [TestCase]
            public void UjEloadasonMindenHelySzabad()
            {
                Assert.AreEqual(84, eloadas.Szabadelyek, "Az előadás nem üres");
            }
            [TestCase]
            public void HelyfoglalasUtanAHelyekSzamaCsokken()
            {
                eloadas.Lefoglal();
                Assert.AreEqual(6, eloadas.Szabadelyek, "A helyek száma hibás");

            }
            [TestCase]
            public void HibasMaradekSzamitas()
            {
                var eloadas2 = new Eloadas(86, 5);
                Assert.AreEqual(31, eloadas.Szabadelyek, "Hibás számítás a maradék férőhelyeknél!");
            }

            [TestCase]
            public void azEloadasTeliVanE()
            {
                Assert.IsFalse(eloadas.Teli(), "Üres előadás teli van");
                for (int i = 0; i < 32; i++)
                {
                    eloadas.Lefoglal();
                }
                Assert.IsTrue(eloadas.Teli(), "Teli előadás megsincs tele");

            }
            [TestCase]


            void NegativEloadasLetrehozas()
            {
                var rep = new Eloadas(-2, -4);
            }

            [TestCase]
            public void AHelyekSzamaNemLehetNegativ()
            {
                Assert.Throws<ArgumentException>(NegativEloadasLetrehozas);
                //alternatív mód->lambda függvény
                Assert.Throws<ArgumentException>(() => {
                    var rep = new Eloadas(0, -4);
                });
            }
            [TestCase]
            public void ASorokSzamaNemLehetNegativ()
            {
                Assert.Throws<ArgumentException>(NegativEloadasLetrehozas);
                //alternatív mód->lambda függvény
                Assert.Throws<ArgumentException>(() => {
                    var rep = new Eloadas(-4, 0);
                });
            }

            [TestCase]
            public void teliEloadasraNeLehessenHelyetFoglalni()
            {
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        eloadas.Lefoglal();
                    }

                }

                bool sikerult = eloadas.Lefoglal();
                Assert.AreEqual(0, eloadas.Szabadelyek);
                Assert.IsTrue(eloadas.Teli());
                Assert.IsFalse(sikerult);
            }



            [TestCase]
            public void SzabadEloadasTeliVan()
            {
                Assert.IsTrue(eloadas.Teli(), "Teli előadás megsincs tele");
                for (int i = 0; i < 32; i++)
                {
                    eloadas.Lefoglal();
                }
                Assert.IsFalse(eloadas.Teli(), "Üres előadás teli van");
            }

            [TestCase]
            public void foglaltNemLehetKisebbMintEgy()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    eloadas.Foglalt(0, 0);
                });
            }


            [TestCase]
            public void aLetezoHelyeknelNemLehetTobbetFoglalni()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    eloadas.Foglalt(7, 81);
                });
            }


        }

    }
}
