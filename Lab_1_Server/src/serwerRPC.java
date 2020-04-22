import org.apache.xmlrpc.WebServer;

public class serwerRPC {

    public static void main(String[] args) {
        try {
            System.out.println("Startuje serwer XML-RPC...");
            int port = 43006;
            WebServer server = new WebServer(port);

            server.addHandler("Kavetskyy", new serwerRPC());
            server.start();
            System.out.println("Serwer wystartował pomyślnie.");
            System.out.println("Nasłuchuje na porcie: " + port);
            System.out.println("Aby zatrzymać serwer nacisnij Ctrl+C");
        } catch (Exception exception) {
            System.err.println("Serwer XML-RPC: " + exception);
        }
    }

    public String fun14(String s, int i, boolean b) {
        String result = "[" + s + "]:" + i;
        return result;
    }
}
