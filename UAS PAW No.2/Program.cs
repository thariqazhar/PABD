using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace UAS_PAW_2
{
    public class Kasir
    {
        /// <summary>
        /// Main Class
        /// </summary>
        /// <remarks> Kelas ini berisi method yang dapat digunakan untuk menjalankan fitur dari aplikasi kasir.
        /// Mulai dari memunculkan main menu, menerima input user, penjumlahan harga barang, dan membuat nota.
        /// </remarks>
        
        public void KasirCafe()
        {
            /// <summary>
            /// Operasi yg berisi seluruh fitur dari aplikasi kasir
            /// </summary>    
            //menampilkan menu
            /// <example>
            /// Jika di run, maka akan muncul tampilan menu
            /// </example>
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("   Silahkan Memilih Menu Yang Anda Inginkan  ");
            Console.WriteLine("---------------------------------------------");
            Console.Write("\n");


            Console.WriteLine("==============   MAKANAN   ==============");
            Console.Write("");
            Console.WriteLine("1. Kue Pie                    : Rp 12000");
            Console.WriteLine("2. Roti Bakar                 : Rp 9000");
            Console.WriteLine("3. Kue Pudding                : Rp 15000");
            Console.WriteLine("4. Kue Sus                    : Rp 17000");
            Console.Write("");

            Console.WriteLine("==============   MINUMAN   ==============");
            Console.Write("");
            Console.WriteLine("1. Kopi Hangat/Dingin         : Rp 7000");
            Console.WriteLine("2. Susu Hangat/Dingin         : Rp 5000");
            Console.WriteLine("3. Teh Hangat/Dingin          : Rp 5000");
            Console.WriteLine("4. Es Boba                    : Rp 10000");

            int jumlah;
            /// <summary>
            /// looping dengan menginput jumlah barang menggunakan kondisi do while
            /// </summary>
            /// <example>
            /// ketika run, user dapat menginput barang jika jumlahnya tidak lebih dari atau sama dengan 100 item.
            /// </example>
            /// <code>
            /// selama jumlah item <= 0 atau jumlah > 100, user tetap dapat menginput
            /// </code>
            do
            {
                Console.Write("\nMasukan Jumlah Barang : ");
                jumlah = int.Parse(Console.ReadLine());
            } while (jumlah <= 0 || jumlah > 100);

            //mendeklarasikan atau mendefinisikan variabel data
            /// <summary>
            /// Pendeklarasian variable yang akan digunakan
            /// </summary>
            string[] nama = new string[jumlah];
            int[] harga = new int[jumlah];
            int total = 0;
            int bayar, kembalian;


            Console.WriteLine("========================");
            Console.WriteLine("Masukan Nama Pelanggan :");

            //deklarasi variabel data string
            string namap1 = Console.ReadLine();

            /// <summary>
            /// Looping menggunakan kombinasi array
            /// </summary>
            /// <code>
            /// selama i < jumlah, sistem akan menampilkan list dari barang
            /// yang dipilih user beserta harganya.
            /// </code>
            for (int i = 0; i < jumlah; i++)
            {
                do
                {
                    //menampilkan input nama barang 
                    Console.WriteLine("====================");
                    Console.Write("Masukkan Nama Barang Ke-" + (i + 1) + " : ");
                    nama[i] = Console.ReadLine();
                }//user harus menginput nama barang diatas 0 karakter sampai dengan 20 karakter
                while (nama[i].Length <= 0 || nama[i].Length >= 20);

                do
                {
                    //menampilkan input harga
                    Console.Write("Masukkan Harga Barang Ke-" + (i + 1) + " : ");
                    harga[i] = int.Parse(Console.ReadLine());
                }//user harus menginput harga barang min 5000 sampai 1000000
                while (harga[i] <= 4000 || harga[i] >= 1000000);
            }
            /// <summary>
            /// Barisan kode ini digunakan untuk memnuculkan daftar barang yang dipilih
            /// </summary>
            /// <example>
            /// jika di run, akan muncul daftar dari barang yang telah dipilih
            /// </example>
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("============================");
            Console.WriteLine("Daftar Barang Yang Dipilih");
            Console.WriteLine("============================");
            for (int i = 0; i < jumlah; i++)
            {
                Console.WriteLine((i + 1) + ". " + nama[i] + " " + harga[i]);
            }
            foreach (int i in harga)
            {
                total += i;
            }

            Console.WriteLine("===================");
            Console.WriteLine("Total Harga : Rp " + total);

            do
            {
                Console.Write("Masukkan Tunai : Rp ");
                bayar = int.Parse(Console.ReadLine());

                //menampilkan kembalian dari uang yang dibayarkan dikurangi uang total
                kembalian = bayar - total;

                //kondisi jika input uang yang dibayarkan kurang
                if (bayar < total)
                {
                    Console.WriteLine("Maaf Uang Anda Tidak Cukup !");
                }
                //kondisi jika input uang yang dibayarkan lebih 
                else //menampilkan kembalian
                {
                    Console.WriteLine("Uang Kembalian Anda : Rp " + kembalian);
                }
            } while (bayar < total);

            Console.Write("\n");
            Console.Write("Nama Pelanggan : {0}", namap1.ToString());
            Console.Write("\n");

            Console.WriteLine("Tanggal Transaksi :" + DateTime.Today.ToString("yyyy-MM-dd"));
            Console.WriteLine("Jam Transaksi :" + DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("=======================================");
            Console.WriteLine("Nama Kasir : Thariq Azhar ");
            Console.WriteLine("Terima Kasih Telah Memesan :)");
            Console.WriteLine("=======================================");

            //mencetak nota
            /// <example>
            /// setelah selesai pembayaran, nota akan muncul sebagi file text
            /// </example>
            using (StreamWriter sw = new StreamWriter(@"D:\Tugas\UAS PAW No.2\Nota/Nota.txt"))
            {
                sw.WriteLine("========================================");
                sw.WriteLine("============ NOTA PEMBAYARAN ===========");
                sw.WriteLine("========================================");
                sw.WriteLine("Nama Barang Yang Dibeli");
                for (int i = 0; i < jumlah; i++)
                {
                    sw.WriteLine((i + 1) + ". " + nama[i] + " " + harga[i]);
                }
                sw.WriteLine("========================================");
                sw.WriteLine("Total Harga           : Rp" + total);
                sw.WriteLine("Tunai                 : Rp" + bayar);
                sw.WriteLine("Kembalian             : Rp" + kembalian);
                sw.WriteLine("\n");
                 
                sw.WriteLine("Nama Pelanggan : {0}", namap1.ToString());
                sw.WriteLine("Tanggal Transaksi :" + DateTime.Today.ToString("yyyy-MM-dd"));
                sw.WriteLine("Jam Transaksi :" + DateTime.Now.ToString("HH:mm:ss"));
                sw.WriteLine("=======================================");
                sw.WriteLine("     Nama Kasir : Thariq Azhar  ");
                sw.WriteLine("     Terima Kasih Telah Memesan :)     ");
                sw.WriteLine("=======================================");
                Console.Write("\n");
                Console.WriteLine("Nota Telah Di Cetak !");
            }
        }
        static void Main(string[] args)
        {
            Kasir cash = new Kasir();
            cash.KasirCafe();
        }
    }
}