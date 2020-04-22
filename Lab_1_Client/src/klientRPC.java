import org.apache.xmlrpc.XmlRpcClient;

import java.util.ArrayList;
import java.util.Vector;

public class klientRPC {

    public static void main(String[] args) {
	try {
	    XmlRpcClient srv = new XmlRpcClient("http://localhost:43006");

        Vector<String> params = new Vector<>();
        params.addElement("Kavetskyy");
        params.addElement("231295");

        Object result = srv.execute("Kavetskyy.getProc", params);
        System.out.println(result);


        klientRPC_Async cb = new klientRPC_Async();
        Vector params3 = new Vector();
        params3.addElement("Kavetskyy");
        params3.addElement(30);
        srv.executeAsync("Kavetskyy.fun203", params3, cb);
        System.out.println("Wywołano asynchroniecznie");

        Vector params2 = new Vector();
        params2.addElement("231295");
        params2.addElement(10);
        params2.addElement(false);
        Object result2 = srv.execute("Kavetskyy.fun14", params2);
        System.out.println(result2);

    } catch (Exception exception) {
	    System.err.println("Klient XML-RPC: " + exception);
    }
    }
}
