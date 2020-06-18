public class Main {

    public static void main(String[] args) {
        double wynik = 0;
        ResultType wynik2;
        CalcObject zObiekt;
        CalcObject2 zObiekt2;

        System.setProperty("java.security.policy", "file:./srv.policy");
        if (System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());

        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in" +
                    "the form: //host_address/service_name");
            return;
        }

        String adres = args[0];
        String adres2 = args[1];

        try {
            zObiekt = (CalcObject) java.rmi.Naming.lookup(adres);
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do: " + adres);
            e.printStackTrace();
            return;
        }

        System.out.println("Referencja do " + adres + " została pobrana.");

        try {
            wynik = zObiekt.calculate(1.1, 2.2);
        } catch (Exception e) {
            System.out.println("Błąd zdalnego wywołania.");
            e.printStackTrace();
            return;
        }

        System.out.println("Wynik: " + wynik);

        try {
            zObiekt2 = (CalcObject2) java.rmi.Naming.lookup(adres2);
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do: " + adres2);
            e.printStackTrace();
            return;
        }

        System.out.println("Referencja do " + adres2 + " została pobrana.");

        try {
            InputType inputType = new InputType();
            inputType.x1 = 4.5;
            inputType.x2 = 4.2;
            inputType.operation = "sub"; //lub "add"

            wynik2 = zObiekt2.calculate(inputType);
        } catch (Exception e) {
            System.out.println("Błąd zdalnego wywołania.");
            e.printStackTrace();
            return;
        }

        System.out.println("Wynik: " + wynik2.result + "\n" + wynik2.result_description);
    }
}
