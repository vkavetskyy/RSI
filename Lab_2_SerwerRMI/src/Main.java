import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Main {

    public static void main(String[] args) {
        try {
            Registry reg = LocateRegistry.createRegistry(1099);
        } catch (Exception e) {
            e.printStackTrace();
        }

        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in" +
                    "the form: //host_address/service_name");
            return;
        }

        System.setProperty("java.security.policy", "file:./srv.policy");
        if (System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());

        try {
            CalcObjImpl implObiektu = new CalcObjImpl();
            CalcObjImpl2 implObiektu2 = new CalcObjImpl2();
            java.rmi.Naming.rebind(args[0], implObiektu);
            java.rmi.Naming.rebind(args[1], implObiektu2);
            System.out.println("Server is registered now.");
            System.out.println("Press Ctrl+C to stop...");
        } catch (Exception e) {
            System.out.println("SERVER CAN'T BE REGISTERED!");
            e.printStackTrace();
        }
    }
}
