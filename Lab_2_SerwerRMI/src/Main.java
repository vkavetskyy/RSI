public class Main {

    public static void main(String[] args) {
        if (args.length == 0)
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");

        if (System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());
    }
}
