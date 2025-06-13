import java.rmi.Naming;
import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class MyClient {

    private static int n;
    public static void main(String[] args) {
        try {
            String serverIP = "172.20.10.2:2099";
            MaxFinder stub = (MaxFinder) Naming.lookup("rmi://" + serverIP + "/xyz");

            Scanner scanner = new Scanner(System.in);
            System.out.print("Nhap so thu nhat: ");
            float a = scanner.nextFloat();
            System.out.print("Nhap so thu hai: ");
            float b = scanner.nextFloat();
            
            float phandu = stub.modulo(a,b);
            System.out.print("Phan du: "+phandu+"\n");
        } catch (Exception e) {
            System.out.println("Loi Client: " + e);
        }
    }
}