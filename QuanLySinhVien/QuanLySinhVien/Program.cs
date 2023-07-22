using System;
using System.Collections.Generic;
using System.IO;

struct Student
{
    public int id;
    public string name;
    public string gender;
    public int age;
    public double mathScore;
    public double physicsScore;
    public double chemistryScore;
    public double averageScore;
    public string academicPerformance;
}

class Program
{
    static List<Student> students = new List<Student>();
    static int currentId = 1;

    static void Main()
    {
        LoadDataFromFile();

        int choice;
        do
        {
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Cap nhap sinh vien boi ID");
            Console.WriteLine("3. Xoa sinh vien boi ID");
            Console.WriteLine("4. Tim kiem theo ten");
            Console.WriteLine("5. Sap xep sinh vien theo diem trung binh");
            Console.WriteLine("6. Sap xep theo ten");
            Console.WriteLine("7. Hien thi danh sach sinh vien");
            Console.WriteLine("8. Ghi danh sach sinh vien vao file \"student.txt\"");
            Console.WriteLine("0. Exit");
            Console.Write("Nhap lua chon: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        UpdateStudentById();
                        break;
                    case 3:
                        DeleteStudentById();
                        break;
                    case 4:
                        FindStudentByName();
                        break;
                    case 5:
                        SortStudentsByAverageScore();
                        break;
                    case 6:
                        SortStudentsByName();
                        break;
                    case 7:
                        DisplayStudents();
                        break;
                    case 8:
                        SaveDataToFile();
                        break;
                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
            }

            Console.WriteLine();
        } while (choice != 0);
    }

    static void AddStudent()
    {
        Student student = new Student();
        student.id = currentId++;

        Console.Write("Nhap ten sinh vien: ");
        student.name = Console.ReadLine();

        Console.Write("Nhap gioi tinh(Nam, nu): ");
        student.gender = Console.ReadLine();

        Console.Write("Nhap tuoi: ");
        int.TryParse(Console.ReadLine(), out student.age);

        Console.Write("Nhap diem toan: ");
        double.TryParse(Console.ReadLine(), out student.mathScore);

        Console.Write("Nhap diem ly: ");
        double.TryParse(Console.ReadLine(), out student.physicsScore);

        Console.Write("Nhap diem hoa: ");
        double.TryParse(Console.ReadLine(), out student.chemistryScore);

        student.averageScore = (student.mathScore + student.physicsScore + student.chemistryScore) / 3;

        if (student.averageScore >= 8)
            student.academicPerformance = "Gioi";
        else if (student.averageScore >= 6.5)
            student.academicPerformance = "Kha";
        else if (student.averageScore >= 5)
            student.academicPerformance = "Trung binh";
        else
            student.academicPerformance = "Yeu";

        students.Add(student);
        Console.WriteLine("Them sinh vien thanh cong!");
    }

    static void UpdateStudentById()
    {
        Console.Write("Nhap ID sinh vien can cap nhap: ");
        int id = int.Parse(Console.ReadLine());

        int index = students.FindIndex(s => s.id == id);
        if (index >= 0)
        {
            Console.WriteLine("Sinh vien can cap nhap: ");
            DisplayStudent(students[index]);

            Student updatedStudent = students[index];
            Console.Write("Nhap ten sinh vien moi: ");
            updatedStudent.name = Console.ReadLine();

            Console.Write("Nhap gioi tinh moi(Nam, nu): ");
            updatedStudent.gender = Console.ReadLine();

            Console.Write("Nhap tuoi moi: ");
            int.TryParse(Console.ReadLine(), out updatedStudent.age);

            Console.Write("Nhap diem toan moi: ");
            double.TryParse(Console.ReadLine(), out updatedStudent.mathScore);

            Console.Write("Nhap diem ly moi: ");
            double.TryParse(Console.ReadLine(), out updatedStudent.physicsScore);

            Console.Write("Nhap diem hoa moi: ");
            double.TryParse(Console.ReadLine(), out updatedStudent.chemistryScore);

            updatedStudent.averageScore = (updatedStudent.mathScore + updatedStudent.physicsScore + updatedStudent.chemistryScore) / 3;

            if (updatedStudent.averageScore >= 8)
                updatedStudent.academicPerformance = "Gioi";
            else if (updatedStudent.averageScore >= 6.5)
                updatedStudent.academicPerformance = "Kha";
            else if (updatedStudent.averageScore >= 5)
                updatedStudent.academicPerformance = "Trung Binh";
            else
                updatedStudent.academicPerformance = "Yeu";

            students[index] = updatedStudent;
            Console.WriteLine("Cap nhap thong tin sinh vien thanh cong!");
        }
        else
        {
            Console.WriteLine("Khong tìm thay thong tin sinh vien da nhap.");
        }
    }

    static void DeleteStudentById()
    {
        Console.Write("Nhap ID sinh vien can xoa: ");
        int id = int.Parse(Console.ReadLine());

        int index = students.FindIndex(s => s.id == id);
        if (index >= 0)
        {
            Console.WriteLine("Sinh vien can xoa: ");
            DisplayStudent(students[index]);

            Console.Write("Ban chac chan muon xoa sinh vien nay? (Y/N): ");
            if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                students.RemoveAt(index);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien co ID da nhap.");
        }
    }

    static void FindStudentByName()
    {
        Console.Write("Nhap ten sinh vien can tim kiem: ");
        string name = Console.ReadLine();

        List<Student> foundStudents = students.FindAll(s => s.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (foundStudents.Count > 0)
        {
            Console.WriteLine("Danh sach sinh vien da nhap: ");
            DisplayStudents(foundStudents);
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien da nhap.");
        }
    }

    static void SortStudentsByAverageScore()
    {
        students.Sort((s1, s2) => s2.averageScore.CompareTo(s1.averageScore));
        Console.WriteLine("Sap xep sinh vien theo diem trung binh thanh cong!");
    }

    static void SortStudentsByName()
    {
        students.Sort((s1, s2) => s1.name.CompareTo(s2.name));
        Console.WriteLine("Sap xep sinh vien theo ten thanh cong!");
    }

    static void DisplayStudent(Student student)
    {
        Console.WriteLine($"ID: {student.id}");
        Console.WriteLine($"Ten: {student.name}");
        Console.WriteLine($"Gioi tinh: {student.gender}");
        Console.WriteLine($"Tuoi: {student.age}");
        Console.WriteLine($"Điem Toan: {student.mathScore}");
        Console.WriteLine($"Điem Ly: {student.physicsScore}");
        Console.WriteLine($"Điem Hoa: {student.chemistryScore}");
        Console.WriteLine($"Điem Trung Binh: {student.averageScore}");
        Console.WriteLine($"Hoc Luc: {student.academicPerformance}");
        Console.WriteLine();
    }

    static void DisplayStudents(List<Student> studentsToDisplay = null)
    {
        if (studentsToDisplay == null)
            studentsToDisplay = students;

        foreach (var student in studentsToDisplay)
        {
            DisplayStudent(student);
        }
    }

    static void LoadDataFromFile()
    {
        try
        {
            if (File.Exists("student.txt"))
            {
                using (StreamReader sr = new StreamReader("student.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 9)
                        {
                            Student student = new Student
                            {
                                id = int.Parse(data[0]),
                                name = data[1],
                                gender = data[2],
                                age = int.Parse(data[3]),
                                mathScore = double.Parse(data[4]),
                                physicsScore = double.Parse(data[5]),
                                chemistryScore = double.Parse(data[6]),
                                averageScore = double.Parse(data[7]),
                                academicPerformance = data[8]
                            };
                            students.Add(student);

                            if (student.id >= currentId)
                                currentId = student.id + 1;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loi khi doc du lieu tu file: " + ex.Message);
        }
    }

    static void SaveDataToFile()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("student.txt"))
            {
                foreach (var student in students)
                {
                    sw.WriteLine($"{student.id},{student.name},{student.gender},{student.age},{student.mathScore},{student.physicsScore},{student.chemistryScore},{student.averageScore},{student.academicPerformance}");
                }
            }

            Console.WriteLine("Ghi danh sach sinh vien vao file \"student.txt\" thanh cong!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loi khi ghi du lieu vao file: " + ex.Message);
        }
    }
}
