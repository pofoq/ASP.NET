import React from "react";
import { Col, Row, Table } from 'react-bootstrap';
import WeatherItem from "./WeatherItem";
import 'bootstrap/dist/css/bootstrap.css';

interface WeatherProps {
    items: WeatherItem[];
}

const WeatherForecast: React.FC<WeatherProps> = (WeatherProps) => {
    return (
        <Table>
            <Row>
                <Col>Date</Col>
                <Col>TemperatureC</Col>
                <Col>TemperatureF</Col>
                <Col>Summary</Col>
            </Row>
            {WeatherProps.items.map(w => (
                <Row>
                    <Col>{w.date.toString()}</Col>
                    <Col>{w.temperatureC}</Col>
                    <Col>{w.temperatureF}</Col>
                    <Col>{w.summary}</Col>
                </Row>
            ))}
        </Table>
    );
};

export default WeatherForecast;
