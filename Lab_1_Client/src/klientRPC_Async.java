import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;

public class klientRPC_Async implements AsyncCallback {

    @Override
    public void handleResult(Object o, URL url, String s) {
        System.err.println("handleResult: " + o + " " + url + " " + s);
    }

    @Override
    public void handleError(Exception e, URL url, String s) {
        System.err.println("handleError: " + e + " " + url + " " + s);
    }
}
