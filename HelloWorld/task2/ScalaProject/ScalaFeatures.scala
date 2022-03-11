import scala.collection.immutable
import scala.util.chaining.scalaUtilChainingOps

object ScalaFeatures {
  def from(a : String) : String = {
    "from " + a
  }

  def sqrts(xs: List[Double]) : List[Double] = {
    for (x <- xs if 0 <= x)
      yield Math.sqrt(x)
  }

  implicit class Pipe[T](val v : T) extends AnyVal {
    def |>[U](f : T => U): U = f(v)
  }

  abstract class Notification

  case class Email(sender: String, title: String, body: String) extends Notification

  case class SMS(caller: String, message: String) extends Notification

  case class VoiceRecording(contactName: String, link: String) extends Notification

  def showNotification(notification: Notification): String = {
    notification match {
      case Email(sender, title, _) =>
        s"You got an email from $sender with title: $title"
      case SMS(number, message) =>
        s"You got an SMS from $number! Message: $message"
      case VoiceRecording(name, link) =>
        s"You received a Voice Recording from $name! Click the link to hear it: $link"
    }
  }

  def main(args : Array[String]): Unit = {
    val a = "Scala"
    print(a.|>(x => from(x)))
    print(a.pipe(from))

    val lst = List(1.0, 2.0, 3.0)
    val newLst = sqrts(lst)
    print(newLst)

    val someSms = SMS("12345", "Are you there?")
    val someVoiceRecording = VoiceRecording("Tom", "voicerecording.org/id/123")
    println(showNotification(someSms))
    println(showNotification(someVoiceRecording))
  }
}