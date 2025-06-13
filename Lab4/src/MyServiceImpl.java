import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.Arrays;

public class MyServiceImpl extends UnicastRemoteObject implements MyService {

    protected MyServiceImpl() throws RemoteException {
        super();
    }
    @Override
    public int findMax(int[] numbers) throws RemoteException {
        if (numbers == null || numbers.length == 0) {
            throw new IllegalArgumentException("Mảng rỗng hoặc null");
        }

        System.out.println("Da nhan mang tu client: " + Arrays.toString(numbers));
        System.out.println("Bat dau tim gia tri lon nhat...");

        int max = numbers[0];
        for (int i = 1; i < numbers.length; i++) {
            if (numbers[i] > max) {
                max = numbers[i];
            }
        }

        System.out.println("Max la: " + max);
        return max;
    
    }
    public String sum(int a, int b)throws java.rmi.RemoteException {
        return "Tong là: " + (a + b);
    }

    @Override
    public String getA(String hi) throws RemoteException {
        System.out.println("Server da nhan: " + hi);
        return "Server " + hi;
    }
}
