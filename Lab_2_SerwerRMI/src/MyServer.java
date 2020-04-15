import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class MyServer {

    public static void main(String[] args) {
        try {
            Registry reg = LocateRegistry.createRegistry(1099);
        } catch (RemoteException e) {
            e.printStackTrace();
        }

        if (args.length == 0)
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");

        if (System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());

        try {
            CalcObjImpl implObiektu = new CalcObjImpl();
            java.rmi.Naming.rebind(args[0], implObiektu);
            System.out.println("Server is registered now :)");
            System.out.println("Press Ctrl+C to stop...");
        } catch (Exception e) {
            System.out.println("Server can't be registered!");
            e.printStackTrace();
            return;
        }
    }
}
