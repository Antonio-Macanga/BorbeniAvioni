import { useEffect, useState } from "react"
import DrzavaService from "../../services/DrzavaService"
import { Button, Table } from "react-bootstrap";
import { NumericFormat } from "react-number-format";
import moment from "moment";
import { GrValidate } from "react-icons/gr";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function DrzavePregled(){

    const[smjerovi, setDrzave] = useState();
    const navigate = useNavigate();

    async function dohvatiDrzave(){
        const odgovor = await DrzavaService.get()
        setDrzave(odgovor)
    }

    // hooks (kuka) se izvodi prilikom dolaska na stranicu Smjerovi
    useEffect(()=>{
        dohvatiDrzave();
    },[])

    function obrisi(sifra){
        if(!confirm('Sigurno obrisati')){
            return;
        }
        brisanjeDrzave(sifra);
    }

    async function brisanjeDrzave(sifra) {
        const odgovor = await DrzavaService.obrisi(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiDrzave();
    }


    return(
        <>
        <Link
        to={RouteNames.DRZAVA_NOVI}
        className="btn btn-success siroko"
        >Dodaj novi smjer</Link>
        <Table striped bordered hover responsive>
            <thead>
                <tr>
                    <th>naziv</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {drzave && drzave.map((smjer,index)=>(
                    <tr key={index}>
                        <td>
                            {drzava.naziv}
                        </td>
                        
                       
                        
                        <td>
                            <Button
                            onClick={()=>navigate(`/drzave/${drzava.sifra}`)}
                            >Promjena</Button>
                            &nbsp;&nbsp;&nbsp;
                            <Button
                            variant="danger"
                            onClick={()=>obrisi(drzava.sifra)}
                            >Obriši</Button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )


}