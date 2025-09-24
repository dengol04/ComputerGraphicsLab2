module ru.golubov.computergraphicslab2task1 {
    requires javafx.controls;
    requires javafx.fxml;


    opens ru.golubov.computergraphicslab2task1 to javafx.fxml;
    exports ru.golubov.computergraphicslab2task1;
}