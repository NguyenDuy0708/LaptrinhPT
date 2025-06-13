import java.rmi.Remote;
import java.rmi.RemoteException;

public interface MaxFinder extends Remote {
    int findMax(int[] var1) throws RemoteException;

    public int sum(int tong, int num);

    public float modulo(float a, float b);
}