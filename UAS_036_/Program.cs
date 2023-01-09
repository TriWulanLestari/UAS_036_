using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UAS_036_
{
    class Node
    {
        public int NomorInduk;
        public string nama;
        public int kelas;
        public Node next;
        public Node prev;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote()
        {
            int nik;
            string nm;
            int kls;
            Console.Write("\nMasukkan Nomor Induk Siswa: ");
            nik = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Siswa: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Kelas Siswa: ");
            kls = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();
            newnode.NomorInduk = nik;
            newnode.nama = nm;
            newnode.kelas = kls;


            if ((START == null) || (kls == START.kelas))
            {
                if ((START != null) && (kls == START.kelas))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (kls == current.kelas))
            {
                if (kls == current.kelas)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }

        public bool delNode(int nik)
        {
            Node previous, current;
            previous = current = null;
            if (Search(nik, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        public bool Search(int kls, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (kls != current.kelas))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }

        public void Traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nThe records in the list are: ");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NomorInduk + " " + currentNode.nama + " " + currentNode.kelas + "\n");
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
        internal class Program
        {
            static void Main(string[] args)
            {
                List obj = new List();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMENU");
                        Console.WriteLine("1. Tambahkan data ");
                        Console.WriteLine("2. Hapus data dari list");
                        Console.WriteLine("3. Lihat semua data pada list");
                        Console.WriteLine("4. Mencari data pada list");
                        Console.WriteLine("5. Keluar");
                        Console.Write("\nMasukkan pilihan (1-5) : ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNote();
                                }
                                break;

                            case '2':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Console.WriteLine("Masukkan Nomor Induk" + " Siswa yang akan dihapus: ");
                                    int nik = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(nik) == false)
                                        Console.WriteLine("\nData ditemukan.");
                                    else
                                        Console.WriteLine("Data Nomor Induk" + +nik + "Hapus");

                                }

                                break;
                            case '3':
                                {
                                    obj.Traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is Empty");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan Kelas" + "Siswa yang akan dicari: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("Data tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nData ditemukan");
                                        Console.WriteLine("\nNomor Induk: " + current.NomorInduk);
                                        Console.WriteLine("\nNama: " + current.nama);
                                        Console.WriteLine("\nKelas: " + current.kelas);
                                    }
                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nGagal");
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nMasukin lagi");
                    }
                }
            }
        }
    }
}
//2.Singly Linked List
//3. Menghapus dan menambahkan elemen posisi terakhir
//4. POP dan PUSH
//5.A.5, B.POSTOERDER

