import java.rmi.Naming;
import java.rmi.registry.LocateRegistry;

public class MyServer {
    public static void main(String[] args) {
        try {
            // Khởi động RMI Registry từ mã Java//Skeleton
            LocateRegistry.createRegistry(2099);//dk tren creta 
            MyService myservice = new MyServiceImpl();
            Naming.rebind("rmi://172.20.10.3:2099/abc", myservice);//create ưhrer,namename
            System.out.println("MyService is running...");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                       
