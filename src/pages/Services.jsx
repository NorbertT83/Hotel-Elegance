import s from '../styles/Services.module.css'
import labels from '../const/Labels';
import TopBar from "../components/TopBar";
import { useGlobal } from '../context/GlobalContext';
import { useUser } from '../context/UserContext';
import { useState, useEffect, useCallback } from 'react';
import { getData, putData } from '../api/apiService';


export default function Services() {
    const { user } = useUser();
    const { language } = useGlobal();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [services, setServices] = useState([]);
    const [editedRowId, setEditedRowId] = useState(null);
    const [editedRowData, setEditedRowData] = useState({});

    const fetchServices = useCallback(async (serviceId = "") => {
        setLoading(true);
        setError(null);
        try {
            const data = await getData(`service/${serviceId ? serviceId : "all"}?sort=name`);
            setServices(data);
        } catch (err) {
            setError(err.message);
            throw err;
        } finally {
            setLoading(false);
        }
    }, []);

    useEffect(() => {
        fetchServices()
    }, [fetchServices]);


    function handleEditClick(service) {
        setEditedRowId(service.id);
        setEditedRowData({ ...service });
    };

    function handleInputChange(e) {
        const { name, value } = e.target;
        setEditedRowData(prev => ({
            ...prev,
            [name]: value
        }));
    };

    async function handleSave() {
        try {
            const result = await putData(`service/${editedRowId}`, editedRowData); // TODO Folytatni backenden a PUT metódust
            console.log("Sikeres mentés:", result);
        } catch (error) {
            alert("Nem sikerült a mentés: " + error.message);
        }
    }

    function handleCancelClick() {
        setEditedRowId(null);
        setEditedRowData({});
    };

    const t = labels[language]?.services || {};

    return ( <main>
        <TopBar page={"services"}></TopBar>

        <div className="contentHeader">
            <div>
                <button className="btn-primary"><i className="fa-solid fa-plus"></i> {t.button1}</button>
                <button className="btn-secondary"><i className="fa-solid fa-plus"></i> {t.button2}</button>
            </div>
        </div>

        <div className={s.container}>
            {error && <div className="error-msg">{error}</div>}
            {loading ? (
                <div className="loader">Adatok betöltése...</div>
            ) : (
            <table>
                <thead>
                    <tr>
                        <th>Megnevezés</th>
                        <th>Leírás</th>
                        <th>Kategória</th>
                        <th>Ár <span>(HUF)</span></th>
                        {user.role === 'admin' && (
                            <th>Művelet</th>
                        )}
                    </tr>
                </thead>
                <tbody>
                    {services.map((service) => (
                        <tr key={service.id}>
                            {editedRowId === service.id ? (
                                <>
                                    <td><input name="name" value={editedRowData.name} onChange={handleInputChange} className={s.editInput} /></td>
                                    <td><input name="description" value={editedRowData.description} onChange={handleInputChange} className={s.editInput} /></td>
                                    <td>
                                        <select name="service_type" value={editedRowData.service_type} onChange={handleInputChange}>
                                            <option value="Cleaning">Cleaning</option>
                                            <option value="Wellness">Wellness</option>
                                        </select>
                                    </td>
                                    <td><input type="number" name="price" value={editedRowData.price} onChange={handleInputChange} className={s.editInput} /></td>
                                    <td className={s.btnCell}>
                                        <button className="btn-primary" onClick={() => handleSave(service.id)}>OK</button>
                                        <button className="btn-warning" onClick={handleCancelClick}>Mégse</button>
                                    </td>
                                </>
                            ) : (
                                <>
                                    <td>{service.name}</td>
                                    <td>{service.description}</td>
                                    <td>{service.service_type}</td>
                                    <td>{service.price},- Ft</td>
                                    {user.role === 'admin' && (
                                        <td className={s.btnCell}>
                                            <button className='btn-primary' onClick={() => handleEditClick(service)}>Szerkeszt</button>
                                        </td>
                                    )}
                                </>
                            )}
                        </tr>
                    ))}
                </tbody>
            </table>
            )
            }
        </div>

        <div className="contentFooter"></div>
    </main>
    )
}