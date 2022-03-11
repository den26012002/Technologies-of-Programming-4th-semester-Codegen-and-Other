import java.util.*;

import scala.collection.JavaConverters;
import scala.collection.mutable.*;

public class ScalaUsing {
    public static void main(String[] args) {
        //just a function
        String a = "Java";
        System.out.println(ScalaFeatures.from(a));

        //for comprehension
        List<Object> lst = new ArrayList<>();
        lst.add(1.0);
        lst.add(2.0);
        lst.add(3.0);
        System.out.println(ScalaFeatures.sqrts(JavaConverters.asScala(lst).toList()));

        //pattern matching
        ScalaFeatures.SMS email = new ScalaFeatures.SMS("12345", "Are you there?");
        System.out.println(ScalaFeatures.showNotification(email));
    }
}
