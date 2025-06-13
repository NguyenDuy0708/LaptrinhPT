package client3;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Random;

public class Client3 {
    public static void main(String[] args) throws Exception {
        DatagramSocket clientSocket = new DatagramSocket();
        InetAddress serverAddress = InetAddress.getByName("172.20.10.2"); 
        byte[] sendData;
        byte[] receiveData = new byte[1024];
        
        Random rand = new Random();
        int N = 1; 
        int[] numbers = new int[N];
        StringBuilder builder = new StringBuilder();
        int evenSum = 0;
        
        System.out.print("Client - Mang: ");
        for (int i = 0; i < N; i++) {
            numbers[i] = rand.nextInt(100); 
            builder.append(numbers[i]).append(" ");
            System.out.print(numbers[i] + " ");
            
        }
        System.out.println();
        
        String dataToSend = builder.toString().trim();
        sendData = dataToSend.getBytes();

        DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, serverAddress, 13000);
        clientSocket.send(sendPacket);

        DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
        clientSocket.receive(receivePacket);

        String response = new String(receivePacket.getData(), 0, receivePacket.getLength());
        System.out.println("Server tra ve: \n" + response);
       
        clientSocket.close();
    }
}
