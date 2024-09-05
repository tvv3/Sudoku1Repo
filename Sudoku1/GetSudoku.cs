using System;

namespace Sudoku1
{
    public class GetSudoku
    {

        ////https://stackoverflow.com/questions/20082221/when-to-use-task-delay-when-to-use-thread-sleep

        // ENDDDDDDDDDDDDDDD GRID VALUES FUNCTION

        // start sudoku generating grid --- de copiat aici prima parte

        public static string modifyGridValues(int[,] grid, ref int[,] gridValues, ref int i, ref int j,
           ref int v, ref int[,] oldGridValues, ref int oldi, ref int oldj, ref int oldv,
           int[,] otherGridPositionsToExclude, int poz, ref int[] minimPoz)
        {
            int[,] gridValuesTest = new int[9, 9];
            int k; bool gol; string gasit; int z; int k2; int k3; int a, b; int x;
            //am pus in grid[i,j]=v; inseamna ca pe pozitia i*9+j avem max 9 valori posibile in grid values 
            // din care scoatem v sau adaugam 1-9 fara v daca nu exista nici una

            //linie k<>i si j=j
            // Random rnd = new Random();
            Random rnd2 = new Random();
            int c;

            // setam ca in grid values pentru coloana i j avem doar o valoare

            for (k3 = 0; k3 < 81; k3++)
                for (k = 0; k < 9; k++)
                { oldGridValues[k3, k] = gridValues[k3, k]; }

            oldi = i;
            oldj = j;
            oldv = v;


            for (k = 0; k < 9; k++)
            {
                gridValues[i * 9 + j, k] = 0;
            }

            gridValues[i * 9 + j, v - 1] = 1;

            //setam valoarea pe linia respectiva

            minimPoz[poz - 1] = 0;

            for (x = 0; x < 9; x++)
            {
                if (x != i)
                { //in fiecare casuta k,j mai putin i,j punem valorile 1-9 fara v ---- de reanalizat si corectata aici !!!!
                    /* gol = true;
                     k3 = 0;
                     for (z = 0; z < 9; z++)
                     {
                         if (gridValues[k * 9 + j, z] > 0) { gol = false; }
                         k3 = k3 + gridValues[k * 9 + j, z];
                     }

                     if (gol)
                     {
                         for (z = 0; z < 9; z++)
                             if (z != v - 1) { gridValues[k * 9 + j, z] = 1; }//valoare posibila
                             else gridValues[k * 9 + j, z] = 0; //de comentat ??
                     }
                     else
                     {//nu este gol

                         if ((grid[k, j] != v) && ((k3 > 1) || (gridValues[k * 9 + j, v - 1] == 0))) { gridValues[k * 9 + j, v - 1] = 0; }
                         else //eroare setare grid
                         {

                             Console.WriteLine("k={0} j={1} v={2} i={3} k3={4}", k, j, v, i, k3);
                             return "falselin";

                         }
                     }*/
                    if (grid[x, j] == v)
                    {
                        ////  Console.WriteLine("k este {0} j={1} v={2} i={3}", x, j, v, i);
                        return "falselin";
                    }
                    else
                    {
                        if (gridValues[x * 9 + j, v - 1] == 1) { gridValues[x * 9 + j, v - 1] = 0; }
                    }
                }//end if k<>i
            }
            //pe coloana i=i, k<>j

            for (k = 0; k < 9; k++)
                if (k != j)
                { //in fiecare casuta i,k punem valorile 1-9 fara v
                    /* gol = true;
                     k3 = 0;
                     for (z = 0; z < 9; z++)
                     {
                         if (gridValues[i * 9 + k, z] > 0) { gol = false; }
                         k3 = k3 + gridValues[i * 9 + k, z];
                     }

                     if (gol)
                     {
                         for (z = 0; z < 9; z++)
                             if (z + 1 != v) { gridValues[i * 9 + k, z] = 1; }//valoare posibila
                             else gridValues[i * 9 + k, z] = 0;//de comentat ???
                     }
                     else
                     {//nu este gol
                         if ((grid[i, k] != v) && ((k3 > 1) || (gridValues[i * 9 + k, v - 1] == 0))) gridValues[i * 9 + k, v - 1] = 0;
                         else
                         {
                             Console.WriteLine("k={0} j={1} v={2} i={3} k3={4}", k, j, v, i, k3);
                             return "falsecol";//nu s-a putut scrie gridul
                         }
                     }*/
                    if (grid[i, k] == v)
                    {
                        //// Console.WriteLine("k={0} j={1} v={2} i={3}", k, j, v, i);
                        return "falsecol";
                    }
                    else if (gridValues[i * 9 + k, v - 1] == 1) { gridValues[i * 9 + k, v - 1] = 0; }

                }//end if k!=j

            //in grila casutei i; j punem pentru toate celelalte casute din grila valori de la 1 la 9 fara v
            a = (i - 1 + 1) / 3 + 1;

            b = (j - 1 + 1) / 3 + 1;

            for (z = (a - 1) * 3 + 1; z <= a * 3; z++)
            {
                for (int g = (b - 1) * 3 + 1; g <= b * 3; g++)
                {
                    if (!((i == z - 1) && (j == g - 1))) //in afara de casuta i,j celelalte casute iau valorile 1-9 fara valoarea v
                    {
                        /*gol = true;
                        k3 = 0;
                        for (k = 0; k < 9; k++)
                        {
                            if (gridValues[(z - 1) * 9 + g - 1, k] > 0) { gol = false; }
                            k3 = k3 + gridValues[(z - 1) * 9 + g - 1, k];
                        }

                        if (gol)
                        {
                            for (k = 0; k < 9; k++)
                                if (k + 1 != v) { gridValues[(z - 1) * 9 + g - 1, k] = 1; }//valoare posibila
                                else gridValues[(z - 1) * 9 + g - 1, k] = 0;//de comentat ???
                        }
                        else
                        { //nu este gol
                            if ((grid[z - 1, g - 1] != v) && ((k3 > 1) || (gridValues[(z - 1) * 9 + g - 1, v - 1] == 0)))
                            { gridValues[(z - 1) * 9 + g - 1, v - 1] = 0; }
                            else //if (grid[z - 1, g - 1] == v )
                            {
                                Console.WriteLine("z={0} g={1} i={2} j={3} v={4} k3={5}", z, g, i, j, v, k3);
                                return "falseab";//nu s-a putut scrie gridul
                            }
                        }
                        */
                        if (grid[z - 1, g - 1] == v)
                        {
                            //// Console.WriteLine("z={0} g={1} i={2} j={3} v={4}", z, g, i, j, v);
                            return "falseGrid";
                        }
                        else if (gridValues[(z - 1) * 9 + g - 1, v - 1] == 1) { gridValues[(z - 1) * 9 + g - 1, v - 1] = 0; }
                    }

                }

            }

            /*for (k = 0; k < 81; k++)
            {
                Console.WriteLine(" ");
                for (z = 0; z < 9; z++)

                    Console.Write("{0} ", gridValues[k, z]);
            }
            Console.ReadKey();*/

            int[] suma = new int[81];
            int minim;
            bool grilarezolvata = true;
            bool eroareNoMoreValues = false;
            minim = 123;
            for (k = 0; k < 81; k++)
            {
                suma[k] = 0;
                for (k3 = 0; k3 < 9; k3++)
                {
                    //if ((poz == -100) || ((poz >= 0) && (otherGridPositionsToExclude[poz - 1, k] == 0)))
                    suma[k] = suma[k] + gridValues[k, k3];
                }
                if (suma[k] == 0)
                {
                    eroareNoMoreValues = true;//a aparut eroarea 
                    //minim = k;
                    break;
                }
                if (eroareNoMoreValues) break;

            }

            if (eroareNoMoreValues) return "falseEroareNoMoreValues";// +k.ToString();

            //daca nu a returnat eroare am suma2 cu suma totala a matricii gridValues

            grilarezolvata = true;

            for (k = 0; k < 9; k++)
            {
                for (k3 = 0; k3 < 9; k3++)
                    if (grid[k, k3] == 0) { grilarezolvata = false; break; }
                if (!grilarezolvata) break;
            }

            if (grilarezolvata) return "trueGrilaRezolvata"; //se opreste cautarea de i, j, v

            //de aici de corectat in jos --- grila nu este inca rezolvata si am putut adauga v e poz i,j caut un nou i,j,v

            for (k = 0; k < 81; k++)
            {
                suma[k] = 0;
                for (k3 = 0; k3 < 9; k3++)
                {
                    if ((poz == -100) || ((poz >= 0) && (otherGridPositionsToExclude[poz - 1, k] == 0)))
                        suma[k] = suma[k] + gridValues[k, k3];
                }
                //if (suma[k] != 1) grilarezolvata = false;
            }

            // if (grilarezolvata == true) return "trueGrilaRezolvataMaiDevreme";
            /* { minim = 1; }
             else
             {*/
            //minim = 2;

            minim = 100;
            int maxim = 0;
            for (k = 0; k < 81; k++)
            {
                i = k / 9; j = k % 9;
                if ((minim > suma[k]) &&
                        //(suma[k] > 1) && (grid[i, j] == 0)) { minim = suma[k]; }
                        (grid[i, j] == 0))
                { minim = suma[k]; }
                if ((maxim < suma[k]) &&
                        //(suma[k] > 1) && (grid[i, j] == 0)) { minim = suma[k]; }
                        (grid[i, j] == 0))
                { maxim = suma[k]; }
            }

            if (minim == 0) return "falseNextPositionNotFoundMinim0";
            //if (maxim < minim) { minim = maxim; }//adica egal cu 1 altfel ramane 2 

            minimPoz[poz - 1] = minim;

            if (maxim <= 0) return "falseNextPositionNotFoundMaxim0";//atentie am verificat deja mai sus ca grila nu este rezolvata!!!

            if (maxim == 1) //block if nounou
            {

                gasit = "falseNoNewPositionFoundMinim1";
                for (k3 = 0; k3 < 81; k3++)
                {
                    for (k = 0; k < 9; k++)

                    {
                        if ((gridValues[k3, k] == 1) && (grid[k3 / 9, k3 % 9] == 0) && ((poz == -100) || ((poz >= 0) && (otherGridPositionsToExclude[poz - 1, k3] == 0))))
                        {
                            i = k3 / 9; j = k3 % 9; v = k + 1; gasit = "true"; break;
                        }
                    }
                    if (gasit == "true") { break; }
                }
                return gasit;
            }


            /*
            if (minim == 100)
            {

                return "false100"; //grila a fost rezolvata mai devreme  sau 

            }
            */
            //}
            //daca nu gasim cu suma[k]>1 atunci am terminat deja grila
            //de adaugat un else aici 

            int cnt = 0;

            for (k = 0; k < 81; k++)
            {
                i = k / 9; j = k % 9;

                if (grid[i, j] == 1) suma[k] = -1;
            }
            int minim2;

            k = rnd2.Next(0, 81);//ia de la 0 la 80

            minim2 = suma[k];

            if (minim2 < 1) { minim2 = minim; }


            for (k = 0; k < 81; k++)
            {
                i = k / 9; j = k % 9;
                if ((((suma[k] == minim) && (poz > 25)) || ((poz <= 25) && (suma[k] == minim2)))
                    //(((suma[k] >= 1) && (maxim > 2)) || ((suma[k] == minim) && (maxim == 2)))
                    && (grid[i, j] == 0)) { cnt++; }
            }

            // Console.WriteLine("cnt={0} cu min={1}",cnt,minim);

            //  int month = rnd.Next(1, 13);
            c = rnd2.Next(1, cnt + 1);// aleg o casuta random cu minim la suma intre 1 si cnt 
                                      //// Console.WriteLine("Random({0} + 1) ={1}", cnt, c);
            gasit = "falseNextPozNotFound";
            for (k = 0; k < 81; k++)
            {
                z = k / 9; k3 = k % 9;
                if ((poz == -100) || ((poz >= 0) && (otherGridPositionsToExclude[poz - 1, k] == 0)))
                { //-1
                    if ((((suma[k] == minim) && (poz > 25)) || ((poz <= 25) && (suma[k] == minim2))) //((suma[k] >= 1) && (maxim > 2)) || ((suma[k] == minim)&&(maxim==2)))*/
                        && (grid[z, k3] == 0) && (c > 0))
                    {
                        c--;
                        if (c == 0)
                        { //am ales cauta k
                          //
                          // Console.WriteLine("Am ales casuta c={0}", c);//de la 0 la 80
                            i = k / 9;
                            j = k % 9;
                            // v=getRandomValuesFrom grid values [k,0-8] unde valoarea este 1
                            cnt = 0;
                            for (k2 = 0; k2 < 9; k2++) { if (gridValues[k, k2] > 0) { cnt++; } }
                            // Console.WriteLine("cnt={0}", cnt);

                            c = rnd2.Next(1, cnt + 1); //cnt minim va fi 1 

                            //Console.WriteLine("c={0}", c);

                            for (k2 = 0; k2 < 9; k2++) if ((gridValues[k, k2] == 1) && (c > 0))
                                {
                                    c--; if (c == 0) { v = k2 + 1; gasit = "true"; break; }
                                }//valoarea noua este de la 1 la 9 iar pozitia de la 0 la 8 deci se adauga 1 }
                                 //break;
                            break;
                        }
                    }
                }//test poz==-1 sau pozitia este permisa
            }//for
            //de verificat daca grila este rezolvabila si daca da return true else return false!!!!
            ////Console.WriteLine("v={0} i={1} j={2} minim={3}", v, i, j, minim);
            return gasit;
        }


        public static void newSudokuGrid(ref int[,] grid)
        {
            int[,] oldGridValues = new int[81, 9];
            int[,] otherGridValuesToExclude = new int[81, 9];
            int[,] otherGridPositionsToExclude = new int[81, 81];
            int[] minimPoz = new int[81];
            bool ok = true;
            int oldi = 0, oldj = 0, oldv = 0;
            int counter2;
            int[,] gridSteps = new int[9, 9];
            int poz = 1;
            int other = 0;
            int i;
            int k;
            int j;
            int v;
            int a = 0;
            int b = 0;
            int[,] gridValues = new int[81, 9];
            int suma;
            Random rnd = new Random();
            //  int month = rnd.Next(1, 13);
            // bool uniqueGrid;
            string uniqueGrid2;
            for (i = 0; i < 81; i++)
                for (j = 0; j < 9; j++)
                {
                    gridValues[i, j] = 1;
                    oldGridValues[i, j] = 1;
                    otherGridValuesToExclude[i, j] = 0;
                }

            for (i = 0; i < 81; i++)
                for (j = 0; j < 81; j++)
                    otherGridPositionsToExclude[i, j] = 0;

            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++)
                    gridSteps[i, j] = 0;
            poz = 1;
            i = rnd.Next(0, 81);//de la 0 pana la 81 fara 81 inclusiv 0
            i = i / 9;
            j = i % 9;
            v = 1;
            grid[i, j] = v;
            gridSteps[i, j] = poz; //1
            //gridValues[i * 9 + j, v-1] = v;
            //Console.WriteLine("modify grid values i={0} j={1} v={2}", i, j, v);
            ////Console.WriteLine("modify grid values i={0} j={1} v={2}", i, j, v);
            otherGridValuesToExclude[i * 9 + j, v - 1] = 1;
            uniqueGrid2 = modifyGridValues(grid, ref gridValues, ref i, ref j, ref v, ref oldGridValues,
                ref oldi, ref oldj, ref oldv, otherGridPositionsToExclude, poz/*-100*/, ref minimPoz); //poz=1 punem pe poz 1

            //otherGridPositionsToExclude[0, i * 9 + j] = 1;//la pozitia poz-1=0 trecem la poz=1 si excludem (i,j)
            //ca sa nu mai punem i,j pe poz 1 cand trecem de la 0
            counter2 = 1;
            while ((counter2 < 300000) && (poz >= 0) && (poz <= 81) && (uniqueGrid2 != "trueGrilaRezolvata")) //and not uniqueGrid already=true
            {  //initial poz=1 ----- am pus i,j,v pe pozitia poz=1
                //if (counter2 > 100) { Console.ReadKey(); }
                if (uniqueGrid2 != "true")
                //{//if uniqueGrid!=true

                {//1

                    if (poz < 0)
                    {
                        //// Console.WriteLine("poz<0");
                        break;

                    }//poate sa ajunga iar la poz=1 prin intoarcere lasam asa sa iasa daca ajunge prin intoarcere la poz 0 
                    if (poz == 0)
                    {
                        counter2++;
                        for (i = 0; i < 81; i++)
                            for (j = 0; j < 9; j++)
                            {
                                gridValues[i, j] = 1;
                                oldGridValues[i, j] = 1;
                                otherGridValuesToExclude[i, j] = 0;
                            }

                        for (i = 0; i < 81; i++)
                            for (j = 0; j < 81; j++)
                                otherGridPositionsToExclude[i, j] = 0;

                        for (i = 0; i < 9; i++)
                            for (j = 0; j < 9; j++)
                                gridSteps[i, j] = 0;
                        poz = 1;
                        i = rnd.Next(0, 81);//de la 0 pana la 81 fara 81 inclusiv 0
                        i = i / 9;
                        j = i % 9;
                        v = 1;
                        grid[i, j] = v;
                        gridSteps[i, j] = poz; //1
                                               //gridValues[i * 9 + j, v-1] = v;
                                               //Console.WriteLine("modify grid values i={0} j={1} v={2}", i, j, v);
                                               //// Console.WriteLine("modify grid values i={0} j={1} v={2}", i, j, v);
                        otherGridValuesToExclude[i * 9 + j, v - 1] = 1;
                        uniqueGrid2 = modifyGridValues(grid, ref gridValues, ref i, ref j, ref v, ref oldGridValues,
                            ref oldi, ref oldj, ref oldv, otherGridPositionsToExclude, poz/*-100*/, ref minimPoz); //poz=1 punem pe poz 1
                        continue;
                    }//
                    ok = false;

                    // if (!((uniqueGrid2 == "false100") || (uniqueGrid2 == "falseNextPozNotFound")))
                    if ((uniqueGrid2 == "falselin") || (uniqueGrid2 == "falsecol") || (uniqueGrid2 == "falseGrid")
                        ||
                        (uniqueGrid2 == "falseEroareNoMoreValues")
                        )
                    {//schimba valoarea cod 1
                     ////Console.WriteLine("      La pasul={5} poz={0} i={1}, j={2} am incercat sa pun v={3} si a rezultat uniqueGrid2={4} deci voi incerca sa schimb valoarea",
                     ////       poz, oldi, oldj, oldv, uniqueGrid2, counter2);

                        other = 0; ok = false;

                        for (int k3 = 0; k3 < 81; k3++)
                            for (k = 0; k < 9; k++)
                            { gridValues[k3, k] = oldGridValues[k3, k]; }

                        /*
                        for (a = 0; a < 9; a++)
                        {
                            for (b = 0; b < 9; b++)
                            {
                                if (gridSteps[a, b] == poz)
                                {

                                    other = grid[a, b];
                                    //grid[a, b] = 0;

                                    ok = true;//am gasit
                                    break;

                                }
                            }
                            if (ok) { break; }//daca am gasit iesi din for
                        }//end primul for
                        */
                        if (gridSteps[oldi, oldj] == poz) if (grid[oldi, oldj] == oldv) { ok = true; other = oldv; }
                        // deci am avut eroare la pasul poz la adaugarea pe pozitia a, b a valorii other 

                        // incercam sa adaugam pe pozitia poz o noua valoare diferita de other si otherValuesToExclude

                        // daca am reusit trecem la poz+1

                        // daca am primit eroare ramanem la poz si adaugam other la otherValuesToExclude 
                        // apoi refacem gridValues=oldgridValues ; oldgridValues=0; 
                        // verific daca exista vreo valoare pt pozitia a,b care sa fie in gridValues si sa nu fie in otherValuesToExclude 
                        // valoare > 0 ----- daca exista rulez pt ea daca nu exista
                        //                                     // ma intorc la poz=poz-1 ; fac otherValues[poz] =0 pt poz-1 adaug other la othervalues[poz-1] si reiau algoritmul;
                        //
                        //Console.WriteLine("Eroare la pozitia a={0} b={1} la adaugarea valorii other={2}={3} ", a, b, other,gridSteps[a,b]);

                        if (!ok) //nu am gasit poz
                        {
                            ////Console.WriteLine("Caz schimba valoarea: Eroare nu am gasit pozitia = {0}", poz);
                            break;
                        }
                        else
                        {//am gasit pozitia
                            a = oldi; b = oldj; //nou ???
                            otherGridValuesToExclude[a * 9 + b, other - 1] = 1; //other are valori de la 1 la 9
                            ok = false; v = -1;
                            /* suma = 0;
                             for (v = 0; v < 9; v++)
                             {
                                 suma = suma + gridValues[a * 9 + b, v];
                             }*/
                            for (v = 0; v < 9; v++)
                            {

                                if //(((suma == 0) || (gridValues[a * 9 + b, v] == 1)) && (otherGridValuesToExclude[a * 9 + b, v] == 0))
                                   ((v != oldv) && (gridValues[a * 9 + b, v] == 1) && ((otherGridValuesToExclude[a * 9 + b, v] == 0)))
                                { ok = true; break; }
                            }
                            v++;//in grid valorile sunt de la 1 la 9
                        }//else am gasit pozitia
                    }//end schimba valoarea cod 1
                    else
                    {
                        ok = false;
                        //trec mai jos direct la pasul urmator pe ramura else not ok
                        ////Console.WriteLine("  ZZZ    La pasul={5} poz={0} i={1}, j={2} am incercat sa pun v={3} si a rezultat uniqueGrid2={4} deci voi trece la pozitia anterioara",
                        ////      poz, oldi, oldj, oldv, uniqueGrid2, counter2);
                    }

                    if (ok) //|| ((uniqueGrid2 == "false100") || (uniqueGrid2 == "falseNextPozNotFound")))
                    //am gasit alta valoare de pus pe pozitia poz adica pe a, b ok=true
                    //scot--sau sunt pe cazul nu mai am pozitii trebuie sa ma intorc o pozitie

                    {
                        counter2++;
                        //v++;// aici da eroare se face v=10 ???
                        ////  Console.WriteLine("Modific valoarea. Am gasit pozitia poz={3} voi apela functia pentru  a={0} b={1} v={2}", a, b, v, poz);
                        //Console.WriteLine("modify grid values a={0} b={1} v={2}", a, b, v);
                        i = oldi;//a
                        j = oldj;// b;
                        grid[i, j] = v;//il vom incerca pe v
                                       //gridSteps[i, j] = poz;//este deja poz dar noi mai setam o data
                                       // poz=poz;

                        //oldGridValues = 0;//de implementat codul --- nu trebuie pus aici 
                        //otherGridValues[i*9+j,k]=0 for k=0,8   --- nu trebuie pus aici
                        //oldi=0; oldj=0;oldv=0;//nu cred ca mai avem nevoie de ele ---- de vazut 
                        for (int k3 = 0; k3 < 81; k3++)
                            for (k = 0; k < 9; k++)
                            { gridValues[k3, k] = oldGridValues[k3, k]; }

                        uniqueGrid2 = modifyGridValues(grid, ref gridValues, ref i, ref j, ref v,
                            ref oldGridValues, ref oldi, ref oldj, ref oldv, otherGridPositionsToExclude,
                            poz/*-100*/, ref minimPoz);
                        //k++;
                    }

                    else //ma intorc cu un pas in urma si incerc intai sa pun aceeasi valoare si sa continui cu alt pas
                         //daca nu mai am pasi incerc sa schimb valoarea trebuie folosita o variabila booleana !!!!!
                         //trebuie sa reiau unde si cum setez othergridpositionstoexclude
                    {
                        ////  Console.WriteLine("oldGridValues si otherValuesToExclude pt oldv={0} ", oldv);
                        ////for (k = 0; k < 9; k++)
                        //// {
                        //// Console.Write("({0},{1}), ", oldGridValues[a * 9 + b, k], otherGridValuesToExclude[a * 9 + b, k]);

                        //// }
                        a = oldi; b = oldj; //ma intorc de la pozitia a,b = oldi,oldj la poz-1
                                            ////  Console.WriteLine("Ma intorc cu un pas in urma");
                        counter2++;
                        for (k = 0; k < 9; k++) { otherGridValuesToExclude[a * 9 + b, k] = 0; }// for k=0,8
                        for (k = 0; k < 81; k++) { otherGridPositionsToExclude[poz - 1, k] = 0; }

                        grid[a, b] = 0;
                        gridSteps[a, b] = 0;//era poz 
                        poz = poz - 1;
                        if (poz > 0) { otherGridPositionsToExclude[poz - 1, a * 9 + b] = 1; }//excludem pe poz+1=vechiul poz (a,b)
                        else
                        {
                            ////  Console.WriteLine("Ma intorc la pozitia 0!!!!");
                            uniqueGrid2 = "maIntorcLaPoz0";
                            continue;
                            //break;
                        }
                        for (int k3 = 0; k3 < 81; k3++)
                            for (k = 0; k < 9; k++)
                            { gridValues[k3, k] = oldGridValues[k3, k]; }

                        //oldGridValues = 0;//de implementat codul --- nu trebuie pus aici 
                        //oldi=0; oldj=0;oldv=0;//nu cred ca mai avem nevoie de ele ---- de vazut 
                        ////Console.WriteLine(" falseGoBackOnePoz la poz={0}", poz);

                        ok = false;

                        for (a = 0; a < 9; a++)
                        {
                            for (b = 0; b < 9; b++)
                            {
                                if (gridSteps[a, b] == poz) /*adica noua poz-1*/
                                {

                                    other = grid[a, b];
                                    //grid[a, b] = 0;

                                    ok = true;//am gasit
                                    break;

                                }
                            }
                            if (ok) { break; }//daca am gasit iesi din for
                        }//end primul for

                        if ((!ok) || (other <= 0))
                        {
                            ////Console.WriteLine("Nu ma pot intoarce la pozitia={0}. Nu am gasit pozitia, a={1} b={2}", poz, a, b);
                            break;
                        }

                        v = other;//setam aceeasi valoare dar random ne va duce probabil pe alta casuta 

                        ////   Console.WriteLine("modify grid values a={0} b={1} v={2}", a, b, v);
                        i = a;
                        j = b;
                        grid[i, j] = v;//il vom incerca pe v


                        gridSteps[i, j] = poz;
                        uniqueGrid2 = modifyGridValues(grid, ref gridValues, ref i, ref j, ref v,
                                ref oldGridValues, ref oldi, ref oldj, ref oldv, otherGridPositionsToExclude,
                                poz, ref minimPoz);


                        /* if (uniqueGrid2 == "falseNextPozNotFound")
                     {

                     }*/
                    }//end else //ma intorc cu un pas in urma 

                }//end if 1

                // }//if uniqueGrid!=true
                else //uniqueGrid2==true
                { //functia a returnat true deci pot trece la i,j,v la pasul urmator
                    counter2++;
                    ////Console.WriteLine("La pasul counter2={3} Am modificat cu succes data trecuta. Acum fac modify grid values i={0} j={1} v={2}", i, j, v, counter2);
                    grid[i, j] = v;
                    poz++;
                    gridSteps[i, j] = poz;
                    //oldGridValues = 0;//de implementat codul
                    //otherGridValues[i*9+j,k]=0 for k=0,8
                    //oldi=0; oldj=0;oldv=0;//nu cred ca mai avem nevoie de ele ---- de vazut 

                    uniqueGrid2 = modifyGridValues(grid, ref gridValues, ref i, ref j, ref v,
                        ref oldGridValues, ref oldi, ref oldj, ref oldv, otherGridPositionsToExclude,
                        poz/*-100*/, ref minimPoz);
                    //k++;
                }//end else  

            }// end while

            ////  Console.WriteLine("Gridul este uniqueGrid2={0}:", uniqueGrid2);
            //// for (i = 0; i < 9; i++)
            ////{
            ////Console.WriteLine(" ");
            ////for (j = 0; j < 9; j++)
            ////Console.Write("{0} ", grid[i, j]);
            ////}
            k = 33;
            for (i = 80; i >= k; i--)
            {
                if (minimPoz[i] > 2) { k = i + 2; break; }
            }
            ////  Console.WriteLine("Gridul partial pentru k={0} este: ", k);
            /* for (i = 0; i < 9; i++)
             {
                //// Console.WriteLine(" ");
                 for (j = 0; j < 9; j++)
                    //// Console.Write("{0} ", gridSteps[i, j] <= k ? grid[i, j] : 0);
             }*/
            /*
             for (i = 0; i < 9; i++)
             {

                 for (j = 0; j < 9; j++)
                     grid[i,j]= gridSteps[i, j] <= k ? grid[i, j] : 0;
             }
             counter2 = 0;
             int[,] copiegrid = new int[9, 9];

             for (i = 0; i < 9; i++)
             {
                 for (j = 0; j < 9; j++)
                 { copiegrid[i, j] = grid[i, j]; }
             }
            */
            // grid = new int[9, 9]
            /* (2 4 0 0 0 9 8 6 5
0 0 0 0 5 8 1 2 4
0 0 5 0 4 2 3 7 9
0 0 0 0 8 4 9 0 0
4 0 0 0 1 7 0 0 0
0 0 9 0 0 5 0 4 0
0 0 0 0 0 3 0 9 0
0 0 8 0 9 6 0 1 0
0 0 6 0 0 0 0 0 0);*/

            /*ok =solveGrid(ref copiegrid, ref counter2,-1,-1);*/


            //// Console.WriteLine("counter2={0} ok={1}", counter2, ok);

            /* Console.WriteLine("gridValues: ");
             for (i = 0; i < 9; i++)
             {
                 Console.WriteLine(" ");
                 for (j = 0; j < 9; j++)
                 {
                     Console.Write("( ");
                     for (k = 0; k < 9; k++)
                         if (gridValues[i * 9 + j, k] == 1) Console.Write("{0} ", k + 1);
                     Console.Write(") , ");
                 }
             }
            */
            /* poz = 1;
             int[,,] solutions = new int[100, 9, 9];


             oldi = -1;
             counter2 = 0;
             Sudoku(ref poz, ref solutions, ref grid, ref gridValues,
                 ref counter2, oldi);

             Console.WriteLine("counter2={0} ok={1}", counter2, ok);
             Console.WriteLine(solutions.Length);

             Console.WriteLine("Gridul partial ultim este ");
             for (i = 0; i < 9; i++)
             {
                 Console.WriteLine(" ");
                 for (j = 0; j < 9; j++)
                     Console.Write("{0} ", solutions[0, i, j]);
             }*/

        }


        //start sudoku solver my own varianta

        public static bool verificaPotAdaugaValoarePosibila(int row, int col, int v, int[,] grid)
        {
            bool ok;
            int x, z, g, a, b;

            ok = true;
            for (x = 0; x < 9; x++)
            {
                if (grid[x, col] == v) { ok = false; break; }
            }
            if (ok)
            {
                for (x = 0; x < 9; x++)
                {
                    if (grid[row, x] == v) { ok = false; break; }
                }
            }

            if (ok)
            {
                a = (row - 1 + 1) / 3 + 1;

                b = (col - 1 + 1) / 3 + 1;

                for (z = (a - 1) * 3 + 1; z <= a * 3; z++)
                {
                    for (g = (b - 1) * 3 + 1; g <= b * 3; g++)
                    {
                        if (grid[z - 1, g - 1] == v) { ok = false; break; }
                    }
                    if (!ok) { break; }
                }
            }


            return ok;


        }

        public static void elimina(int row, int col, ref int[,] grid, ref int[,] gridValues)
        {
            int oldv, v;

            //verificaPotAdaugaValoarePosibila(row1, col1, oldv, grid)
            bool ok;
            int x, z, g, a, b;

            oldv = grid[row, col];
            grid[row, col] = 0;
            v = oldv;

            for (x = 0; x < 9; x++)
            {
                if (x != row)
                {
                    if (verificaPotAdaugaValoarePosibila(x, col, v, grid)) { gridValues[x * 9 + col, v - 1] = 1; }
                }
            }

            for (x = 0; x < 9; x++)
            {
                if (x != col)
                {
                    if (verificaPotAdaugaValoarePosibila(row, x, v, grid)) { gridValues[row * 9 + x, v - 1] = 1; }
                }
            }



            a = (row - 1 + 1) / 3 + 1;

            b = (col - 1 + 1) / 3 + 1;

            for (z = (a - 1) * 3 + 1; z <= a * 3; z++)
            {
                for (g = (b - 1) * 3 + 1; g <= b * 3; g++)
                {
                    if ((z - 1 != row) && (g - 1 != col))
                    {
                        if (verificaPotAdaugaValoarePosibila(z - 1, g - 1, v, grid)) { gridValues[(z - 1) * 9 + g - 1, v - 1] = 1; }
                    }
                }

            }

            return;
        }

        public static void eliminaFinal(int row, int col, ref int[,] grid, ref int[,] gridValues)
        {
            int oldv, v;

            //verificaPotAdaugaValoarePosibila(row1, col1, oldv, grid)
            //bool ok;
            int x, y;

            oldv = grid[row, col];
            grid[row, col] = 0;
            v = oldv;
            
            for (x = 0; x < 9; x++)
            {
                for (y=0;y<9;y++)
                if ((grid[row,col]==0)&&(!((x == row)&&(y==col))))
                {
                    if (verificaPotAdaugaValoarePosibila(x, y, v, grid)) { gridValues[x * 9 + y, v - 1] = 1; }
                }
            }


            return;
        }

        /* public static bool verificaGrilaRezolvabila(int[,] grid, int[,] gridValues)
         {
             bool ok;
             int suma;
             ok = false;
             for (int i = 0; i < 81; i++)
             {
                 if (grid[i / 9, i % 9] == 0)
                 {
                     suma = 0;
                     for (int k = 0; k < 9; k++) suma = suma + gridValues[i, k];
                     if (suma == 1) { ok = true; break; }
                 }
             }

             return ok;
         }*/

        public static bool verificaGrilaRezolvabila2(int[,] grid, int[,] gridValues, int oldi, int oldv)
        {
            bool ok;
            int suma, row = oldi / 9, col = oldi % 9;
            ok = false;
            if (oldv <= 0) return false;
            if (grid[row, col] == 0)//l-am eliminat deja
            {
                suma = 0;
                for (int k = 0; k < 9; k++) suma = suma + gridValues[oldi, k];
                if ((suma == 1) && (gridValues[oldi, oldv - 1] == 1)) { ok = true; }
            }

            return ok;
        }

        public static bool verificaGrilaRezolvabila2final(int[,] grid, int[,] gridValues, int oldi, int oldv)
        {
            bool ok;
            int suma, row = oldi / 9, col = oldi % 9;
            ok = false;
            if (oldv <= 0) return false;
           if (grid[row, col] ==0)//old one is eliminated
            {
                suma = 0;
                for (int k = 0; k < 9; k++) suma = suma + gridValues[oldi, k];
                if ((suma == 1) && (gridValues[oldi, oldv - 1] == 1)) { ok = true; }
            }

            return ok;
        }

        public static void copyGrid(ref int[,] a, int[,] b, int n, int m)
        {
            int i, j;

            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                    a[i, j] = b[i, j];
        }


        public static bool checkCandidat(int i, int[,] grid, int poz)
        {
            int a, b, x, y;
            a = i / 9; b = i % 9;
            if ((poz >= 10) && (poz < 60))
                return true;
            //caz1
            x = b - 1; y = b + 1;
            if ((x >= 0) && (x <= 8) && (y >= 0) && (y <= 8))
                if ((grid[a, x] == 0) && (grid[a, y] == 0)) return false;
            //caz2
            x = a - 1; y = a + 1;
            if ((x >= 0) && (x <= 8) && (y >= 0) && (y <= 8))
                if ((grid[x, b] == 0) && (grid[y, b] == 0)) return false;

            //caz3
            x = b - 1; y = b - 2;
            if ((x >= 0) && (x <= 8) && (y >= 0) && (y <= 8))
                if ((grid[a, x] == 0) && (grid[a, y] == 0)) return false;
            //caz4
            x = a - 1; y = a - 1;
            if ((x >= 0) && (x <= 8) && (y >= 0) && (y <= 8))
                if ((grid[x, b] == 0) && (grid[y, b] == 0)) return false;

            //caz5
            x = b + 1; y = b + 2;
            if ((x >= 0) && (x <= 8) && (y >= 0) && (y <= 8))
                if ((grid[a, x] == 0) && (grid[a, y] == 0)) return false;
            //caz6
            x = a + 1; y = a + 2;
            if ((x >= 0) && (x <= 8) && (y >= 0) && (y <= 8))
                if ((grid[x, b] == 0) && (grid[y, b] == 0)) return false;


            return true;
        }
        public static int getCandidati(ref int[,] candidati, int[,] grid, int[,] gridValues, int poz)
        {
            int nr = 0;
            int suma;
            int i;
            Random rnd2 = new Random();
           /* int poz = 0;
            for (int a = 0; a < 9; a++)
                for (int b = 0; b < 9; b++)
                { if (grid[a, b] == 0) poz++; }
           */
            
            /*if (poz==1)
            {
                for (i = 0; i < 81; i++)
                {
                    candidati[i / 9, i % 9] = 0;
                }
                i = rnd2.Next(0, 81);
                candidati[i / 9, i % 9] = 1;
                return 1;
            }*/
            


            for (i = 0; i < 81; i++)
            {
                candidati[i / 9, i % 9] = 0;
                if (grid[i / 9, i % 9] > 0)
                {
                    if ((checkCandidat(i, grid, poz)))
                    {
                        suma = 0;
                        for (int k = 0; k < 9; k++) { suma = suma + gridValues[i, k]; }
                        if (suma /*>=*/ == 1) { nr++; candidati[i / 9, i % 9] = 1; }
                    }
                }
            }

            return nr;
        }



        public static string Sudoku7bun(int poz,/*ref int poz,*/ ref int[,,] solutions, ref int[,] grid, int[,] grid2,
           ref int[,] gridValues,
       ref int counter, ref int[] solpoz, ref int nrsol, int oldi, ref bool gasit, int pozmax)
        {
            //int poz2;
            int i, row, col;//, oldv;
           // int pozmax = 51; //pt 49 imi da 33 pt 52 imi da 30 pt 53 imi da 29 ??
            //int nrsolmax = 1;//atentie acum merge mereu pt 1
            bool ok;
            int[,] oldGridValues = new int[81, 9];
            int nrcandidati;
            int[,] candidati = new int[9, 9];
            Random rnd2 = new Random();
            counter++;
            //string s;

            if (counter > 300000)
            {
                return "counter";
            }
            if (gasit) return "true1";


            nrcandidati = getCandidati(ref candidati, grid, gridValues, poz);

            
            //int poz = 1;
            /*for (int a = 0; a < 9; a++)
                for (int b = 0; b < 9; b++)
                    if (grid[a, b] == 0) poz++;*/
            
            if //((nrcandidati <= 0) && (poz > pozmax))
                (poz > pozmax)
            {
                for (int a = 0; a < 9; a++)
                    for (int b = 0; b < 9; b++)
                        solutions[nrsol, a, b] = grid[a, b];
                nrsol++;
                gasit = true;
                return "true2";
            }
            
            //if (nrsol >= nrsolmax) return "gata5";
            if (nrcandidati <= 0) return "false no more candidati";
            //i = rnd2.Next(0, nrcandidati);//ia de la 0 la 81-poz fara 81-poz
            //poz este pozitia curenta prin absurd daca ajung la poz=81 trebuie sa-mi dea 0 
            //daca poz=1 poate sa-mi dea de la 0 la 80 --- corect
            int nrc = nrcandidati;
            for (int i1 = 0; i1 < nrc; i1++)
            {
                if (gasit) return "true3";
                i = i1;

                row = -1; col = -1;
                for (row = 0; row < 9; row++)
                {
                    for (col = 0; col < 9; col++)
                    { if (candidati[row, col] == 1) i--; if (i == -1) break; }
                    if (i == -1) break;
                }
                if (i != -1) return "eroarei-1";//eroare 
                                                //else continua cu row si col
                                                //row = i / 9; col = i % 9;
                                                // oldv = grid2[row, col];
                                                //oldGridValues=gridValues
                copyGrid(ref oldGridValues, gridValues, 81, 9);
                elimina(row, col, ref grid, ref gridValues);
                /*
                poz2 = 0;//era 0
                for (int a = 0; a < 9; a++)
                    for (int b = 0; b < 9; b++)
                        if (grid[a, b] == 0) poz2++;
                //if (poz != poz2) Console.WriteLine("poz {0} {1}", poz, poz2);
                poz = poz2;
                //sunt la pozitia poz calculata mai sus
                */
                //poz--;//?????
                //poz++;//pt ca am facut elimina 
                if (poz >= 2)
                {

                    ok = verificaGrilaRezolvabila2(grid, gridValues, oldi, grid2[oldi / 9, oldi % 9]);
                }
                else
                {
                    ok = true;
                }
                /*if (poz>=pozmax-1)
                { Console.WriteLine($"poz={poz} ok={ok} row={row} col={col} oldv={oldv}"); 
                }*/
                if (ok)
                {
                    //else
                    if (!gasit) { solpoz[poz - 1] = row * 9 + col; }
                    // SINGURA LINIE PENTRU SOLPOZ !!!! SA NU STERG !!!
                    //Console.WriteLine($"solpoz: {poz-1} {row} {col} {grid2[row,col]}");
                    //poz++;
                   // elimina(row, col, ref grid, ref gridValues);
                    if (poz <= pozmax) //
                    {
                        Sudoku7bun(poz+1,/*ref poz,*/ ref solutions, ref grid, grid2, ref gridValues, ref counter,
                            ref solpoz, ref nrsol, row * 9 + col, ref gasit, pozmax);
                        if (gasit) return "true4";
                    }
                   else
                    {

                        for (int a = 0; a < 9; a++)
                            for (int b = 0; b < 9; b++)
                                solutions[nrsol, a, b] = grid[a, b];
                        //Console.WriteLine("grid03 {0}",grid[0, 0]);
                        nrsol++;
                        gasit = true;
                        return "true5";

                        //return 
                    }
                    //solpoz[poz - 1] = 0; //??
                   // poz--;//pt ca adaug mai jos elementul
                    grid[row, col] = grid2[row, col];//adaug inapoi elementul
                    copyGrid(ref gridValues, oldGridValues, 81, 9);
                    //if (gasit) return "true4si5";//nu mai trebuie aici
                }
                else
                {
                    
                    //poz--;//pt ca adaug mai jos elementul si sunt pe elese
                   grid[row, col] = grid2[row, col];
                    //solutions[] += grid;
                    //gridValues=oldGridValues
                   copyGrid(ref gridValues, oldGridValues, 81, 9);
                    if (gasit) return "true123";
                    //if gasit ???
                    //if (nrcandidati <= 1) return "un singur candidat analizat deja!!!!";
                    //solpoz[poz - 1] = 0;
                    /*poz = 1;//pt ca am adaugat ce eliminasem
                    for (int a = 0; a < 9; a++)
                        for (int b = 0; b < 9; b++)
                            if (grid[a, b] == 0) poz++;
                    */
                    
                   /* if (poz > pozmax)
                    {


                        for (int a = 0; a < 9; a++)
                            for (int b = 0; b < 9; b++)
                                solutions[nrsol, a, b] = grid[a, b];
                        //Console.WriteLine("grid03 {0}",grid[0, 0]);
                        nrsol++;
                        gasit = true;
                        return "true6";


                    }*/
                    
                    //  if (nrsol >= nrsolmax) return "gata";

                }//else
            }//for
             //poz--;
            return "iesire";
        }


        public static string Sudoku7final(int poz,/*ref int poz,*/ ref int[,,] solutions, ref int[,] grid, int[,] grid2,
          ref int[,] gridValues,
      ref int counter, ref int[] solpoz, ref int nrsol, int oldi, ref bool gasit, int pozmax)
        {
            //int poz2;
            int i, row, col;//, oldv;
                            // int pozmax = 51; //pt 49 imi da 33 pt 52 imi da 30 pt 53 imi da 29 ??
                            //int nrsolmax = 1;//atentie acum merge mereu pt 1
            bool ok;
            int[,] oldGridValues = new int[81, 9];
           // int nrcandidati;
           // int[,] candidati = new int[9, 9];
            Random rnd2 = new Random();
            counter++;
            //string s;

            if ((pozmax>=53)&&(counter > 2000000))
            {
                return "counter";
            }

            if ((pozmax < 53) && (counter > 1000000))
            {
                return "counter";
            }

            //nrcandidati = getCandidati(ref candidati, grid, gridValues, poz);


            //int poz = 1;
            /*for (int a = 0; a < 9; a++)
                for (int b = 0; b < 9; b++)
                    if (grid[a, b] == 0) poz++;*/

            if //((nrcandidati <= 0) && (poz > pozmax))
                (poz > pozmax)
            {
                for (int a = 0; a < 9; a++)
                    for (int b = 0; b < 9; b++)
                        solutions[nrsol, a, b] = grid[a, b];
                nrsol++;
                gasit = true;
                return "true2";
            }

            if (gasit) return "true1";
            //if (nrsol >= nrsolmax) return "gata5";
            // if (nrcandidati <= 0) return "false no more candidati";
            //i = rnd2.Next(0, nrcandidati);//ia de la 0 la 81-poz fara 81-poz
            //poz este pozitia curenta prin absurd daca ajung la poz=81 trebuie sa-mi dea 0 
            //daca poz=1 poate sa-mi dea de la 0 la 80 --- corect
            
            int nrc = 81;// nrcandidati;
           // if (poz == 1) nrc = 1;//il iau pe 0 pe poz 1
           // if (poz == 2) nrc = 2;//il iau pe 1 pe poz 2 pt ca pe 0 l-am luat deja
            for (int i1 = 0; i1 < nrc; i1++)
            {

                if (gasit) return "true3";
                i = i1;
                
                row = i/9; col = i%9;

                if (grid[row, col] != 0) //nu l-am eliminat inca
                {//if 1
                   // suma = 0;
                   // for (int k = 0; k < 9; k++) { suma = suma + gridValues[i, k]; }
                   // if (suma /*>=*/ == 1)
                    //{
                        //if2
                        //else
                        // copyGrid(ref oldGridValues, gridValues, 81, 9);
                        // elimina(row, col, ref grid, ref gridValues);
                        /*
                        poz2 = 0;//era 0
                        for (int a = 0; a < 9; a++)
                            for (int b = 0; b < 9; b++)
                                if (grid[a, b] == 0) poz2++;
                        //if (poz != poz2) Console.WriteLine("poz {0} {1}", poz, poz2);
                        poz = poz2;
                        //sunt la pozitia poz calculata mai sus
                        */
                        //poz--;//?????
                        //poz++;//pt ca am facut elimina 
                        if (poz > 2)
                        {
                            //grid[row, col] = grid2[row, col];//de scos
                            ok = verificaGrilaRezolvabila2final(grid, gridValues, oldi, grid2[oldi / 9, oldi % 9]);
                        }
                        else
                        {
                            ok = true;
                        }
                        /*if (poz>=pozmax-1)
                        { Console.WriteLine($"poz={poz} ok={ok} row={row} col={col} oldv={oldv}"); 
                        }*/
                        if (ok)
                        {

                            //else
                            if (!gasit) { solpoz[poz - 1] = row * 9 + col; }
                            // SINGURA LINIE PENTRU SOLPOZ !!!! SA NU STERG !!!
                            //Console.WriteLine($"solpoz: {poz-1} {row} {col} {grid2[row,col]}");
                            //poz++;
                            copyGrid(ref oldGridValues, gridValues, 81, 9);

                            eliminaFinal(row, col, ref grid, ref gridValues);
                            if (poz <= pozmax) //
                            {
                                Sudoku7final(poz + 1,/*ref poz,*/ ref solutions, ref grid, grid2, ref gridValues, ref counter,
                                    ref solpoz, ref nrsol, row * 9 + col, ref gasit, pozmax);
                                if (gasit) return "true4";
                            }
                            else
                            {

                                for (int a = 0; a < 9; a++)
                                    for (int b = 0; b < 9; b++)
                                        solutions[nrsol, a, b] = grid[a, b];
                                //Console.WriteLine("grid03 {0}",grid[0, 0]);
                                nrsol++;
                                gasit = true;
                                return "true5";

                                //return 
                            }
                            //solpoz[poz - 1] = 0; //??
                            // poz--;//pt ca adaug mai jos elementul
                            grid[row, col] = grid2[row, col];//adaug inapoi elementul
                            copyGrid(ref gridValues, oldGridValues, 81, 9);
                            if (gasit) return "true4si5";//nu mai trebuie aici
                        }
                        else
                        {

                            //poz--;//pt ca adaug mai jos elementul si sunt pe elese
                            // grid[row, col] = grid2[row, col];
                            //solutions[] += grid;
                            //gridValues=oldGridValues
                            // copyGrid(ref gridValues, oldGridValues, 81, 9);
                            if (gasit) return "true123";
                            //if gasit ???
                            //if (nrcandidati <= 1) return "un singur candidat analizat deja!!!!";
                            //solpoz[poz - 1] = 0;
                            /*poz = 1;//pt ca am adaugat ce eliminasem
                            for (int a = 0; a < 9; a++)
                                for (int b = 0; b < 9; b++)
                                    if (grid[a, b] == 0) poz++;
                            */

                            if (poz > pozmax)
                            {


                                for (int a = 0; a < 9; a++)
                                    for (int b = 0; b < 9; b++)
                                        solutions[nrsol, a, b] = grid[a, b];
                                //Console.WriteLine("grid03 {0}",grid[0, 0]);
                                nrsol++;
                                gasit = true;
                                return "true6";


                            }

                            //  if (nrsol >= nrsolmax) return "gata";

                        }//else
                   // }//if2
                }//if1
            }//for
             //poz--;
            return "iesire";
        }









        public static bool GetNextSudoku(ref int[,] grila2, ref int[,] solutie, int pozmax)//string[] args
        {

            //int counter = 1;
            int i, j, k;
            //int[,] s = new int[9, 9];

            int[,] grid= new int[9,9];/* = {
{ 1, 4, 5, 6, 3, 9, 2, 8, 7 },
{ 7, 2, 8, 5, 4, 1, 9, 3, 6 },
{ 6, 9, 3, 8, 2, 7, 4, 1, 5},
{ 2, 1, 4, 7, 9, 6, 3, 5, 8},
{3, 5, 9, 1, 8, 4, 7, 6, 2},
{8, 6, 7, 2, 5, 3, 1, 9, 4},
{ 4, 7, 6, 3, 1, 5, 8, 2, 9},
{ 9, 8, 1, 4, 6, 2, 5, 7, 3},
{ 5, 3, 2, 9, 7, 8, 6, 4, 1}
            };*/

            int[,] grid2=new int[9,9];/* = {
{ 1, 4, 5, 6, 3, 9, 2, 8, 7 },
{ 7, 2, 8, 5, 4, 1, 9, 3, 6 },
{ 6, 9, 3, 8, 2, 7, 4, 1, 5},
{ 2, 1, 4, 7, 9, 6, 3, 5, 8},
{3, 5, 9, 1, 8, 4, 7, 6, 2},
{8, 6, 7, 2, 5, 3, 1, 9, 4},
{ 4, 7, 6, 3, 1, 5, 8, 2, 9},
{ 9, 8, 1, 4, 6, 2, 5, 7, 3},
{ 5, 3, 2, 9, 7, 8, 6, 4, 1}
            };*/

            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++) { grid[i, j] = 0; }



            newSudokuGrid(ref grid);
            ////Console.WriteLine("End generare sudoku complet!");
            ////Console.ReadKey();

            if (grid[0, 0] == 0)
            {
                for (i = 0; i < 9; i++)
                    for (k = 0; k < 9; k++)
                    {
                        grila2[i, k] = 0;
                        solutie[i, k] = 0;
                    }
                return false;
            }

            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++) { grid2[i, j] = grid[i, j];
                   /* grila2[i, j] = grid[i, j];
                    solutie[i, j] = grid[i, j];*/
                }

            //return true;
            int poz;

            int[,,] solutions = new int[1, 9, 9];
            int[,] gridValues = new int[81, 9];
            int nrsol = 0;
            for (i = 0; i < 81; i++)
            {

                for (k = 0; k < 9; k++)
                {
                    gridValues[i, k] = 0;

                }
                gridValues[i, grid[i / 9, i % 9] - 1] = 1;
            }

            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++)
                    solutions[0, i, j] = 10;

            int[] solpoz = new int[81];


            //int oldi = -1;
            int counter2 = 0;
            bool gasit = false;
            poz = 1;
            //MessageBox.Show("Noua grila partiala se genereaza acum ....");
            Sudoku7final(poz,/*ref poz,*/ ref solutions, ref grid, grid2, ref gridValues,
                ref counter2, ref solpoz, ref nrsol, -1, ref gasit, pozmax);

            //if (nrsol == 0) apelez sudoku final pt pozmax-1 


                //Console.WriteLine("counter2={0} poz={1} rez={2}", counter2, poz, rez);
                //Console.WriteLine(solutions.Length);
                /*
                ////Console.WriteLine("Gridul complet este ");
                for (i = 0; i < 9; i++)
                {
                    Console.WriteLine(" ");
                    for (j = 0; j < 9; j++)
                        Console.Write("{0} ", grid2[i, j]);
                }
                */
                // int z = poz;
            /*    int poz2 = 0;//era 0
            for (int a = 0; a < 9; a++)
                for (int b = 0; b < 9; b++)
                    if (grid[a, b] == 0) poz2++;
            poz = poz2;
            solutions[0, solpoz[poz] / 9, solpoz[poz] % 9] =
                  grid2[solpoz[poz] / 9, solpoz[poz] % 9];//am pus din nou in grid!!!
            */
            /* Console.WriteLine("Gridul partial este {0} ", nrsol);
             if (nrsol >= 0)
             {
                 for (i = 0; i < 9; i++)
                 {
                     Console.WriteLine(" ");
                     for (j = 0; j < 9; j++)
                         Console.Write("{0} ", solutions[0, i, j]);
                 }
             }
            */
            /*
            Console.WriteLine("Gridul partial altul ar fi");
            if (nrsol > 1)
            {
                for (i = 0; i < 9; i++)
                {
                    Console.WriteLine(" ");
                    for (j = 0; j < 9; j++)
                        Console.Write("{0} ", solutions[nrsol-1, i, j]);
                }
            }
            */
            //// Console.WriteLine(" Solutia este: ");
            //for (i = 80;i>=0; i--)
            //  Console.Write($"{solpoz[i]} ");

            /*Console.WriteLine("Gridul se completeaza astfel: {0} ", solpoz[0]);*/
            /*
            for (k = poz - 1; k >= 0; k--)
            {
                i = solpoz[k] / 9;
                j = solpoz[k] % 9;
                Console.WriteLine($" {i + 1} {j + 1} {grid2[i, j]}");
            }

            Console.ReadKey();
            */
            //noutate absoluta : 

            if (nrsol >= 1)
            {
                for (i = 0; i < 9; i++)
                    for (k = 0; k < 9; k++)
                    {
                        grila2[i, k] = grid2[i, k];
                        solutie[i, k] = solutions[0, i, k];
                    }
                return true;
            }
            //else
            for (i = 0; i < 9; i++)
                for (k = 0; k < 9; k++)
                {
                    grila2[i, k] = 0;
                    solutie[i, k] = 0;
                }
            return false;
        }
    

    public GetSudoku()
    {
    }
}
}