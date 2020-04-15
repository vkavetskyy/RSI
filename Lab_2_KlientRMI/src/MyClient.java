public class MyClient {

    public static void main(String[] args) {
	    double wynik = 0;
	    CalcObject zObiekt = null;

	    if (args.length == 0)
	        System.out.println("You have to enter RMI object address in the form: //host_address/service_name");

        System.out.println(args[0]);
	    String adres = args[0];

        if (System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());

        try {
            zObiekt = (CalcObject) java.rmi.Naming.lookup(adres);
        } catch (Exception exception) {
            System.out.println("Nie można pobrać referencji do " + adres);
            exception.printStackTrace();
        }

        System.out.println("Referencja do " + adres + " jest pobrana.");

        try {
            assert zObiekt != null;
            wynik = zObiekt.calculate(1.1, 2.2);
        } catch (Exception exception) {
            System.out.println("Błąd zdalnego wywołania.");
            exception.printStackTrace();
        }

        System.out.println("Wynik: " + wynik);
    }
}
