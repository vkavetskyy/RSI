public class Main {

    public static void main(String[] args) {
        if (args.length == 0)
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");

        if (System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());

        try {
            CalcObjImpl implObiektu = new CalcObjImpl();
            java.rmi.Naming.rebind(args[0], implObiektu);
            System.out.println("Server is registered now :)");
            System.out.println("Press Ctrl+C to stop...");
        } catch (Exception exception) {
            System.out.println("Server can't be registered!");
            exception.printStackTrace();
        }
    }
}
