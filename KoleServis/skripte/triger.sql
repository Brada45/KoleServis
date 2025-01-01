DELIMITER $$

CREATE TRIGGER trg_after_insert_stavka_dio
AFTER INSERT ON stavka_dio
FOR EACH ROW
BEGIN
    DECLARE available_quantity INT;
    DECLARE error_message VARCHAR(255);

    -- Proverava dostupnu količinu dijela
    SELECT Kolicina INTO available_quantity 
    FROM dio 
    WHERE id_dio = NEW.Dio_id_dio;

    -- Proverava da li je dostupna količina dovoljna
    IF available_quantity < NEW.Kolicina THEN
        SET error_message = CONCAT('Nije moguće dodati dio. Nedovoljna količina za dio sa šifrom: ', NEW.Dio_id_dio);
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = error_message;
    ELSE
        -- Smanjuje količinu u tabeli dio
        UPDATE dio
        SET Kolicina = Kolicina - NEW.Kolicina
        WHERE id_dio = NEW.Dio_id_dio;
    END IF;
END$$

DELIMITER ;
