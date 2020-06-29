
using Swan.Logging;
using Swan.Threading;
using System;
using System.Device.Gpio;
using System.Text;
using System.Threading;

namespace KartOkuyucu
{


    class Program
    {




        static void Main(string[] args)
        {
            GpioController pin = new GpioController();
            int wiegand_counter2_3 = 300000;
            int wiegand_counter4_17 = 300000;
            int wiegand_counter27_22 = 300000;
            int wiegand_counter10_9 = 300000;
            int wiegand_counter11_0 = 300000;
            int wiegand_counter5_6 = 300000;
            int wiegand_counter13_19 = 300000;
            int wiegand_counter14_15 = 300000;

            int wiegand_data_counter2_3 = 0;
            int wiegand_data_counter4_17 = 0;
            int wiegand_data_counter27_22 = 0;
            int wiegand_data_counter10_9 = 0;
            int wiegand_data_counter11_0 = 0;
            int wiegand_data_counter5_6 = 0;
            int wiegand_data_counter13_19 = 0;
            int wiegand_data_counter14_15 = 0;

            ulong id_code2_3 = 0;
            ulong id_code4_17 = 0;
            ulong id_code27_22 = 0;
            ulong id_code10_9 = 0;
            ulong id_code11_0 = 0;
            ulong id_code5_6 = 0;
            ulong id_code13_19 = 0;
            ulong id_code14_15 = 0;

            int i = 0;
            int us = 0;
            int j;
            ulong ekle;

            char[] data2_3 = new char[50];
            char[] data4_17 = new char[50];
            char[] data27_22 = new char[50];
            char[] data10_9 = new char[50];
            char[] data11_0 = new char[50];
            char[] data5_6 = new char[50];
            char[] data13_19 = new char[50];
            char[] data14_15 = new char[50];

            for (i = 0; i < 34; ++i)
            {
                data2_3[i] = '0';
                data4_17[i] = '0';
                data27_22[i] = '0';
                data10_9[i] = '0';
                data11_0[i] = '0';
                data5_6[i] = '0';
                data13_19[i] = '0';
                data14_15[i] = '0';
            }
            //2 - 3
            pin.OpenPin(2);
            pin.OpenPin(3);
            pin.SetPinMode(2, PinMode.InputPullUp);
            pin.SetPinMode(3, PinMode.InputPullUp);
            //4 - 17
            pin.OpenPin(4);
            pin.OpenPin(17);
            pin.SetPinMode(4, PinMode.InputPullUp);
            pin.SetPinMode(17, PinMode.InputPullUp);
            //27 - 22
            pin.OpenPin(27);
            pin.OpenPin(22);
            pin.SetPinMode(27, PinMode.InputPullUp);
            pin.SetPinMode(22, PinMode.InputPullUp);
            //10 - 9
            pin.OpenPin(10);
            pin.OpenPin(9);
            pin.SetPinMode(10, PinMode.InputPullUp);
            pin.SetPinMode(9, PinMode.InputPullUp);
            //11 - 0
            pin.OpenPin(11);
            pin.OpenPin(0);
            pin.SetPinMode(11, PinMode.InputPullUp);
            pin.SetPinMode(0, PinMode.InputPullUp);
            //5 - 6
            pin.OpenPin(5);
            pin.OpenPin(6);
            pin.SetPinMode(5, PinMode.InputPullUp);
            pin.SetPinMode(6, PinMode.InputPullUp);
            //13 - 19
            pin.OpenPin(13);
            pin.OpenPin(19);
            pin.SetPinMode(13, PinMode.InputPullUp);
            pin.SetPinMode(19, PinMode.InputPullUp);
            //14 - 15
            pin.OpenPin(14);
            pin.OpenPin(15);
            pin.SetPinMode(14, PinMode.InputPullUp);
            pin.SetPinMode(15, PinMode.InputPullUp);

            while (true)
            {
                //2(d0) - 3(d1)
                int deger2 = (int)pin.Read(2);
                int deger3 = (int)pin.Read(3);
                if (deger2 == 0 || deger3 == 0)
                {
                    deger2 = (int)pin.Read(2);
                    deger3 = (int)pin.Read(3);
                    if (deger2 == 1 && deger3 == 0)
                    {
                        data2_3[wiegand_data_counter2_3] = '1';
                        wiegand_data_counter2_3 = wiegand_data_counter2_3 + 1;
                        while (wiegand_counter2_3 != 0)
                        {
                            wiegand_counter2_3 = wiegand_counter2_3 - 1;
                        }
                        wiegand_counter2_3 = 300000;
                    }
                    deger2 = (int)pin.Read(2);
                    deger3 = (int)pin.Read(3);
                    if (deger2 == 0 && deger3 == 1)
                    {
                        data2_3[wiegand_data_counter2_3] = '0';
                        wiegand_data_counter2_3 = wiegand_data_counter2_3 + 1;

                        while (wiegand_counter2_3 != 0)
                        {
                            wiegand_counter2_3 = wiegand_counter2_3 - 1;
                        }
                        wiegand_counter2_3 = 300000;
                    }
                }


                //4(d0)-17(d1)
                int deger4 = (int)pin.Read(4);
                int deger17 = (int)pin.Read(17);
                if (deger4 == 0 || deger17 == 0)
                {
                    deger4 = (int)pin.Read(4);
                    deger17 = (int)pin.Read(17);
                    if (deger4 == 1 && deger17 == 0)
                    {
                        data4_17[wiegand_data_counter4_17] = '1';
                        wiegand_data_counter4_17 = wiegand_data_counter4_17 + 1;
                        while (wiegand_counter4_17 != 0)
                        {
                            wiegand_counter4_17 = wiegand_counter4_17 - 1;
                        }
                        wiegand_counter4_17 = 300000;
                    }
                    deger4 = (int)pin.Read(4);
                    deger17 = (int)pin.Read(17);
                    if (deger4 == 0 && deger17 == 1)
                    {
                        data4_17[wiegand_data_counter4_17] = '0';
                        wiegand_data_counter4_17 = wiegand_data_counter4_17 + 1;
                        while (wiegand_counter4_17 != 0)
                        {
                            wiegand_counter4_17 = wiegand_counter4_17 - 1;
                        }
                        wiegand_counter4_17 = 300000;
                    }
                }

                ////27(d0)-22(d1)
                //int deger27 = (int)pin.Read(27);
                //int deger22 = (int)pin.Read(22);
                //if (deger22 == 0 || deger27 == 0)
                //{
                //    deger27 = (int)pin.Read(27);
                //    deger22 = (int)pin.Read(22);
                //    if (deger2 == 1 && deger3 == 0)
                //    {
                //        data27_22[wiegand_data_counter27_22] = '1';
                //        wiegand_data_counter27_22 = wiegand_data_counter27_22 + 1;
                //        while (wiegand_counter27_22 != 0)
                //        {
                //            wiegand_counter27_22 = wiegand_counter27_22 - 1;
                //        }
                //        wiegand_counter27_22 = 300000;
                //    }


                //    deger27 = (int)pin.Read(27);
                //    deger22 = (int)pin.Read(22);
                //    if (deger2 == 0 && deger3 == 1)
                //    {


                //        data27_22[wiegand_data_counter27_22] = '0';
                //        wiegand_data_counter27_22 = wiegand_data_counter27_22 + 1;

                //        while (wiegand_counter27_22 != 0)
                //        {
                //            wiegand_counter27_22 = wiegand_counter27_22 - 1;
                //        }
                //        wiegand_counter27_22 = 300000;

                //    }
                //}


                //10(d0)-9(d1)
                int deger10 = (int)pin.Read(10);
                int deger9 = (int)pin.Read(9);
                if (deger10 == 0 || deger9 == 0)
                {
                    deger10 = (int)pin.Read(10);
                    deger9 = (int)pin.Read(9);
                    if (deger10 == 1 && deger9 == 0)
                    {
                        data10_9[wiegand_data_counter10_9] = '1';
                        wiegand_data_counter10_9 = wiegand_data_counter10_9 + 1;
                        while (wiegand_counter10_9 != 0)
                        {
                            wiegand_counter10_9 = wiegand_counter10_9 - 1;
                        }
                        wiegand_counter10_9 = 300000;
                    }


                    deger10 = (int)pin.Read(10);
                    deger9 = (int)pin.Read(9);
                    if (deger10 == 0 && deger9 == 1)
                    {
                        data10_9[wiegand_data_counter10_9] = '0';
                        wiegand_data_counter10_9 = wiegand_data_counter10_9 + 1;
                        while (wiegand_counter10_9 != 0)
                        {
                            wiegand_counter10_9 = wiegand_counter10_9 - 1;
                        }
                        wiegand_counter10_9 = 300000;
                    }
                }



                ////11(d0)-0(d1)
                //int deger11 = (int)pin.Read(11);
                //int deger0 = (int)pin.Read(0);
                //if (deger11 == 0 || deger0 == 0)
                //{
                //    deger11 = (int)pin.Read(11);
                //    deger0 = (int)pin.Read(0);
                //    if (deger2 == 11 && deger0 == 0)
                //    {
                //        data11_0[wiegand_data_counter11_0] = '1';
                //        wiegand_data_counter11_0 = wiegand_data_counter11_0 + 1;
                //        while (wiegand_counter11_0 != 0)
                //        {
                //            wiegand_counter11_0 = wiegand_counter11_0 - 1;
                //        }
                //        wiegand_counter11_0 = 300000;
                //    }
                //    deger11 = (int)pin.Read(11);
                //    deger0 = (int)pin.Read(0);
                //    if (deger11 == 0 && deger0 == 1)
                //    {
                //        data11_0[wiegand_data_counter11_0] = '0';
                //        wiegand_data_counter11_0 = wiegand_data_counter11_0 + 1;
                //        while (wiegand_counter11_0 != 0)
                //        {
                //            wiegand_counter11_0 = wiegand_counter11_0 - 1;
                //        }
                //        wiegand_counter11_0 = 300000;
                //    }
                //}


                //5(d0)-6(d1)
                int deger5 = (int)pin.Read(5);
                int deger6 = (int)pin.Read(6);
                if (deger5 == 0 || deger6 == 0)
                {
                    deger5 = (int)pin.Read(5);
                    deger6 = (int)pin.Read(6);
                    if (deger5 == 1 && deger6 == 0)
                    {
                        data5_6[wiegand_data_counter5_6] = '1';
                        wiegand_data_counter5_6 = wiegand_data_counter5_6 + 1;
                        while (wiegand_counter5_6 != 0)
                        {
                            wiegand_counter5_6 = wiegand_counter5_6 - 1;
                        }
                        wiegand_counter5_6 = 300000;
                    }
                    deger5 = (int)pin.Read(5);
                    deger6 = (int)pin.Read(6);
                    if (deger5 == 0 && deger6 == 1)
                    {
                        data5_6[wiegand_data_counter5_6] = '0';
                        wiegand_data_counter5_6 = wiegand_data_counter5_6 + 1;
                        while (wiegand_counter5_6 != 0)
                        {
                            wiegand_counter5_6 = wiegand_counter5_6 - 1;
                        }
                        wiegand_counter5_6 = 300000;
                    }
                }



                ////13(d0)-19(d1)
                //int deger13 = (int)pin.Read(13);
                //int deger19 = (int)pin.Read(19);
                //if (deger13 == 0 || deger19 == 0)
                //{
                //    deger13 = (int)pin.Read(13);
                //    deger19 = (int)pin.Read(19);
                //    if (deger13 == 1 && deger19 == 0)
                //    {
                //        data13_19[wiegand_data_counter13_19] = '1';
                //        wiegand_data_counter13_19 = wiegand_data_counter13_19 + 1;
                //        while (wiegand_counter13_19 != 0)
                //        {
                //            wiegand_counter13_19 = wiegand_counter13_19 - 1;
                //        }
                //        wiegand_counter13_19 = 300000;
                //    }
                //    deger13 = (int)pin.Read(13);
                //    deger19 = (int)pin.Read(19);
                //    if (deger13 == 0 && deger19 == 1)
                //    {
                //        data13_19[wiegand_data_counter13_19] = '0';
                //        wiegand_data_counter13_19 = wiegand_data_counter13_19 + 1;
                //        while (wiegand_counter13_19 != 0)
                //        {
                //            wiegand_counter13_19 = wiegand_counter13_19 - 1;
                //        }
                //        wiegand_counter13_19 = 300000;
                //    }
                //}


                ////14(d0)-15(d1)
                //int deger14 = (int)pin.Read(14);
                //int deger15 = (int)pin.Read(15);
                //if (deger14 == 0 || deger15 == 0)
                //{
                //    deger14 = (int)pin.Read(14);
                //    deger15 = (int)pin.Read(15);
                //    if (deger14 == 1 && deger15 == 0)
                //    {
                //        data14_15[wiegand_data_counter14_15] = '1';
                //        wiegand_data_counter14_15 = wiegand_data_counter14_15 + 1;
                //        while (wiegand_counter14_15 != 0)
                //        {
                //            wiegand_counter14_15 = wiegand_counter14_15 - 1;
                //        }
                //        wiegand_counter14_15 = 300000;
                //    }
                //    deger14 = (int)pin.Read(14);
                //    deger15 = (int)pin.Read(15);
                //    if (deger14 == 0 && deger15 == 1)
                //    {

                //        data14_15[wiegand_data_counter14_15] = '0';
                //        wiegand_data_counter14_15 = wiegand_data_counter14_15 + 1;
                //        while (wiegand_counter14_15 != 0)
                //        {
                //            wiegand_counter14_15 = wiegand_counter14_15 - 1;
                //        }
                //        wiegand_counter14_15 = 300000;
                //    }
                //}




                if (wiegand_data_counter2_3 == 34)
                {
                    for (j = 32; j >= 1; --j)//2-3
                    {

                        if (data2_3[j] == '1')
                        {
                            ekle = (ulong)Math.Pow(2, us);
                            id_code2_3 = id_code2_3 + ekle;

                        }

                        us += 1;
                    }
                    us = 0;
                    ekle = 0;
                    if (id_code2_3 != 0)
                    {
                        Console.Write("1 numara:");
                        Console.WriteLine("{0}", id_code2_3);
                    }
                    wiegand_data_counter2_3 = 0;

                    id_code2_3 = 0;
                    for (i = 0; i < 34; ++i)
                    {
                        data2_3[i] = '0';

                    }
                }



                if (wiegand_data_counter4_17 == 34)
                {
                    for (j = 32; j >= 1; --j)//4-17
                    {

                        if (data4_17[j] == '1')
                        {
                            ekle = (ulong)Math.Pow(2, us);
                            id_code4_17 = id_code4_17 + ekle;

                        }

                        us += 1;
                    }
                    us = 0;
                    ekle = 0;
                    if (id_code4_17 != 0)
                    {
                        Console.Write("2 numara:");
                        Console.WriteLine("{0}", id_code4_17);
                    }
                    wiegand_data_counter4_17 = 0;

                    id_code4_17 = 0;
                    for (i = 0; i < 34; ++i)
                    {

                        data4_17[i] = '0';

                    }
                }

                //if (wiegand_data_counter27_22 == 34)
                //{
                //    for (j = 32; j >= 1; --j)//27-22
                //    {

                //        if (data27_22[j] == '1')
                //        {
                //            ekle = (ulong)Math.Pow(2, us);
                //            id_code27_22 = id_code27_22 + ekle;

                //        }

                //        us += 1;
                //    }
                //    if (id_code27_22 != 0)
                //        Console.Write("{0}", id_code27_22);
                //    wiegand_data_counter27_22 = 0;

                //    id_code27_22 = 0;
                //    us = 0;
                //    ekle = 0;
                //    for (i = 0; i < 34; ++i)
                //    {

                //        data27_22[i] = '0';

                //    }
                //}

                if (wiegand_data_counter10_9 == 34)
                {
                    for (j = 32; j >= 1; --j)//10-9
                    {

                        if (data10_9[j] == '1')
                        {
                            ekle = (ulong)Math.Pow(2, us);
                            id_code10_9 = id_code10_9 + ekle;

                        }

                        us += 1;
                    }
                    us = 0;
                    ekle = 0;
                    if (id_code10_9 != 0)
                    {
                        Console.Write("3 numara:");
                        Console.WriteLine("{0}", id_code10_9);
                    }
                    wiegand_data_counter10_9 = 0;

                    id_code10_9 = 0;
                    for (i = 0; i < 34; ++i)
                    {

                        data10_9[i] = '0';

                    }

                }

                //if (wiegand_data_counter11_0 == 34)
                //{
                //    for (j = 32; j >= 1; --j)//11-0
                //    {

                //        if (data11_0[j] == '1')
                //        {
                //            ekle = (ulong)Math.Pow(2, us);
                //            id_code11_0 = id_code11_0 + ekle;

                //        }

                //        us += 1;
                //    }
                //    us = 0;
                //    ekle = 0;
                //    if (id_code11_0 != 0)
                //        Console.Write("{0}", id_code11_0);
                //    wiegand_data_counter11_0 = 0;

                //    id_code11_0 = 0;
                //    for (i = 0; i < 34; ++i)
                //    {

                //        data11_0[i] = '0';

                //    }
                //}

                if (wiegand_data_counter5_6 == 34)
                {
                    for (j = 32; j >= 1; --j)//5-6
                    {

                        if (data5_6[j] == '1')
                        {
                            ekle = (ulong)Math.Pow(2, us);
                            id_code5_6 = id_code5_6 + ekle;

                        }

                        us += 1;
                    }
                    us = 0;
                    ekle = 0;
                    if (id_code5_6 != 0)
                    {
                        Console.Write("4 numara:");
                        Console.WriteLine("{0}", id_code5_6);
                    }
                    wiegand_data_counter5_6 = 0;

                    id_code5_6 = 0;
                    for (i = 0; i < 34; ++i)
                    {

                        data5_6[i] = '0';

                    }
                }

                //if (wiegand_data_counter13_19 == 34)
                //{
                //    for (j = 32; j >= 1; --j)//13-19
                //    {

                //        if (data13_19[j] == '1')
                //        {
                //            ekle = (ulong)Math.Pow(2, us);
                //            id_code13_19 = id_code13_19 + ekle;

                //        }

                //        us += 1;
                //    }
                //    us = 0;
                //    ekle = 0;
                //    if (id_code13_19 != 0)
                //        Console.Write("{0}", id_code13_19);
                //    wiegand_data_counter13_19 = 0;

                //    id_code13_19 = 0;
                //    for (i = 0; i < 34; ++i)
                //    {

                //        data13_19[i] = '0';

                //    }
                //}

                //if (wiegand_data_counter14_15 == 34)  
                //{
                //    for (j = 32; j >= 1; --j)//14-15
                //    {

                //        if (data14_15[j] == '1')
                //        {
                //            ekle = (ulong)Math.Pow(2, us);
                //            id_code14_15 = id_code14_15 + ekle;

                //        }

                //        us += 1;
                //    }
                //    us = 0;
                //    ekle = 0;
                //    if (id_code14_15 != 0)
                //        Console.Write("{0}", id_code14_15);
                //    wiegand_data_counter14_15 = 0;
                //    id_code14_15 = 0;
                //    for (i = 0; i < 34; ++i)
                //    {
                //        data14_15[i] = '0';
                //    }
                //}
                us = 0;
            }
        }
    }
}





