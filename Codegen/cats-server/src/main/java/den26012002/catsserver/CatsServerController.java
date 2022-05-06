package den26012002.catsserver;

import den26012002.catsdto.CatToServerDto;
import den26012002.catsdto.CatsOwnerToServerDto;
import den26012002.catsservice.*;
import den26012002.catsentities.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.GregorianCalendar;

@RestController
public class CatsServerController {
    private ICatsService _service = new CatsService();

    CatsServerController() {

    }

    @GetMapping("/cats/get/{id}")
    public ResponseEntity<Cat> getCatById(
            @PathVariable int id) {
        return new ResponseEntity<Cat>(_service.getCatById(id), HttpStatus.OK);
    }

    @GetMapping("/cats_owners/get/{id}")
    public ResponseEntity<CatsOwner> getCatsOwnerById(
            @PathVariable int id) {
        return new ResponseEntity<CatsOwner>(_service.getCatsOwnerById(id), HttpStatus.OK);
    }

    @PostMapping("/cats/register")
    public void registerCat(
            @RequestBody CatToServerDto cat) {
        _service.registerCat(cat.getName(), cat.getDateOfBirth(), cat.getColor(), cat.getOwnerId());
    }

    @PostMapping("/cats_owners/register")
    public void registerCatsOwner(
            @RequestBody CatsOwnerToServerDto catsOwner) {
        _service.registerCatsOwner(catsOwner.getName(), catsOwner.getDateOfBirth());
    }

    @PostMapping("/cats/add_friends")
    public void addFriends(
            @RequestParam int id1,
            @RequestParam int id2) {
        _service.addFriends(id1, id2);
    }
}