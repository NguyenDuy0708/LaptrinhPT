package sever3;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class Sever3 {
    public static void main(String args[]) throws Exception {
        DatagramSocket serverSocket = new DatagramSocket(13000);
        byte[] receiveData = new byte[1024];

        System.out.println("Server is running and waiting for client...");

        while (true) {
            DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
            serverSocket.receive(receivePacket);

            // Lấy chuỗi dữ liệu từ client
            String str = new String(receivePacket.getData(), 0, receivePacket.getLength()).trim();

            System.out.println("From Client: " + str);

            // Kiểm tra điều kiện dừng
            if (str.equalsIgnoreCase("bye")) {
                System.out.println("Client disconnected.");
                break;
            }

            String[] parts = str.split("\\s+");
            StringBuilder result = new StringBuilder();

            for (String part : parts) {
                try {
                    int number = Integer.parseInt(part);
                    if (number % 2 == 0) {
                        result.append(number).append(" ");
                    }
                } catch (NumberFormatException e) {
                    // Bỏ qua nếu không phải số nguyên
                }
            }

            // Gửi phản hồi về client
            String sendStr = "Cac so chan la: " + result.toString().trim();
            System.out.println(sendStr);

            byte[] sendData = sendStr.getBytes();


            InetAddress clientIP = receivePacket.getAddress();
            int clientPort = receivePacket.getPort();

            DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, clientIP, clientPort);
            serverSocket.send(sendPacket);
        }

        serverSocket.close();
    }
}