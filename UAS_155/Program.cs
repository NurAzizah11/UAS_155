using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_155
{
    class Node
    {
        public int nik;
        public string nama;
        public Node next;
        public int kk;
        public int noHp;
        public string alamat;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }

        public void tambahData() //Menambahkan node
        {
            int noNIK, noKK, nmrHP;
            string nm, almt;
            Console.Write("\nMasukkan nomor NIK penduduk: ");
            noNIK = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama penduduk: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan nomor KK: ");
            noKK = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nomor HP: ");
            nmrHP = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan alamat penduduk: ");
            almt = Console.ReadLine();
            Node newnode = new Node();
            newnode.nik = noNIK;
            newnode.nama = nm;
            newnode.kk = noKK;
            newnode.noHp = nmrHP;
            newnode.alamat = almt;

            //Jika node ditambahkan diawal
            if (START == null || noNIK <= START.nik)
            {
                if ((START!= null) && (noNIK == START.nik))
                {
                    Console.WriteLine("\nDuplikasi NIK tidak diperbolehkan\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            //Tambahkan node baru
            Node previous, current;
            previous = START;
            current = START;


            while ((current != null) && (noNIK >= current.nik))
            {
                if (noNIK == current.nik)
                {
                    Console.WriteLine("\nDuplikat NIK tidak diperbolehkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*Setelah loop for di atas dijalankan, prev dan arus akan diputar seperti itu
             * cara posisi untuk node baru berada di antara mereka */
            newnode.next = current;
            previous.next = newnode;
        }

        public bool hapusData(int noNIK) //Menghapus node
        {
            Node previous, current;
            previous = current = null;
            //Mengecek data apakah ada di list atau tidak
            if (cariData(noNIK, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        //mencari data
        public bool cariData(int noKK, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current!= null) && (noKK != current.nik))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }

        public void tampilkanData() //Menampilkan data
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong :\n");
            else
            {
                Console.WriteLine("\nList data penduduk :\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.nik + " " + currentNode.nama + "\n");
                Console.WriteLine();
            }

        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan data");
                    Console.WriteLine("2. Menghapus data");
                    Console.WriteLine("3. Menampilkan data");
                    Console.WriteLine("4. Mengurutkan data");
                    Console.WriteLine("5. Mencari data");
                    Console.WriteLine("6. Keluar");
                    Console.Write("\nMasukkan pilihan (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.tambahData();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nMasukkan NIK" + "penduduk yang akan dihapus: ");
                                int nik = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.hapusData(nik) == false)
                                    Console.WriteLine("\nNIK " + " dihapus ");
                            }
                            break;
                        case '3':
                            {
                                obj.tampilkanData();
                            }
                            break;
                        case '4':
                            {
                                obj.tampilkanData();
                            }
                            break;
                        case '5':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong\n");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan nomor KK" + "penduduk yang akan dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.cariData(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan");
                                    Console.WriteLine("\nNomor KK:" + current.kk);
                                    Console.WriteLine("\nNama:" + current.nama);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan salah");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nPeriksa nilai");
                }
            }
        }
    }
}

/*
2.Algoritma yang digunakan yaitu :
1)	Bubble sort
Bubble Sort adalah algoritma pengurutan paling sederhana yang bekerja dengan berulang kali menukar elemen yang berdekatan jika berada dalam urutan yang salah.
2)	Linear search
Linear Search merupakan sebuah teknik pencarian data dengan menelusuri semua data satu per satu. Apabila ditemukan kecocokan data maka program akan mengembalikan output, jika tidak pencarian akan terus berlanjut hingga akhir dari array tersebut. Algoritma ini tidak cocok untuk set data dengan jumlah besar karena kompleksitas dari algorithma ini adalah Ο(n) di mana n adalah jumlah item. Jika data yang dicari berada pada paling akhir dari array, maka program harus menelusuri semua array terlebih dahulu.
3. Algoritma Queue merupakan struktur data dimana satu data dapat ditambakan diakhir disebut Rear dan data dihapus dari yang paling terkahir disebut Front
4. a) 5
    b) Cara membaca struktur pohon dengan metode PostOrder : 
1.Kunjungi kiri node tersebut,
• Jika kiri bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kiri tersebut. 
• Jika kiri kosong (NULL), lanjut ke langkah kedua. 
2.	 Kunjungi kanan node tersebut,
• Jika kanan bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kanan tersebut. 
• Jika kanan kosong (NULL), lanjut ke langkah ketiga. 
3.	 Cetak isi (data) node yang sedang dikunjungi. Proses untuk node ini selesai, tuntaskan proses yang sama untuk node yang dikunjungi sebelumnya.
*/

