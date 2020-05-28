package main

import (
	"fmt"
)


type Vehicle struct {
	Id int
	Make string
	Model string
	FuelConsumption float32
	Color string
}

func NewVehicle(make string, model string, fuelConsumption float32, color string) *Vehicle {
	VehicleId++
	return &Vehicle{Id: VehicleId, Make: make, Model: model, FuelConsumption: fuelConsumption, Color: color}
}

func (v *Vehicle) move() {
	fmt.Println("Vehicle " + v.Model + ", id " + v.Color + " is moving.")
}

func (v *Vehicle) viewDetails() {
	fmt.Println(v.Id)
	fmt.Println(v.Make)
	fmt.Println(v.Model)
	fmt.Println(v.FuelConsumption)
	fmt.Println(v.Color)
}


type Car struct {
	*Vehicle
	SeatsNumber int
	HasTowBar bool
}

func NewCar(make string, model string, fuelConsumption float32, color string, seatsNumber int, hasTowBar bool) *Car {
	return &Car{NewVehicle(make, model, fuelConsumption, color), seatsNumber, hasTowBar}
}

func (c *Car) move() {
	fmt.Println("Car " + c.Model + ", id " + c.Make + " is moving.")
}

func (c *Car) drift() {
	fmt.Println("Car " + c.Color + ", id " + c.Make + " is drifting.")
}

func (c *Car) viewDetails() {
	fmt.Println(c.Id)
	fmt.Println(c.Make)
	fmt.Println(c.Model)
	fmt.Println(c.FuelConsumption)
	fmt.Println(c.Color)
	fmt.Println(c.SeatsNumber)
	fmt.Println(c.HasTowBar)
}


type Motorcycle struct {
	*Vehicle
	Weight int
	EngineCapacity int
}

func NewMotorcycle(make string, model string, fuelConsumption float32, color string, weight int, engineCapacity int) *Motorcycle {
	return &Motorcycle{NewVehicle(make, model, fuelConsumption, color), weight, engineCapacity}
}

func (m *Motorcycle) viewDetails() {
	fmt.Println(m.Id)
	fmt.Println(m.Make)
	fmt.Println(m.Model)
	fmt.Println(m.FuelConsumption)
	fmt.Println(m.Color)
	fmt.Println(m.Weight)
	fmt.Println(m.EngineCapacity)
}

type IVehicle interface {
	move()
	viewDetails()
}

var VehicleId = -1


func main() {

	vehicles := []IVehicle{
		NewCar("Suzuki", "Samurai", float32(9.2), "red", int(4), true),
		NewCar("Suzuki", "Jimny", float32(7.4), "blue", int(2), false),
		NewCar("Nissan", "Patrol", float32(8.0), "black", int(5), true),
		NewMotorcycle("Kawasaki", "Ninja", float32(6.2), "yellow", int(174), int(1000)),
		NewMotorcycle("Suzuki", "ER", float32(4.3), "blue", int(118), int(500)),
		NewMotorcycle("Honda", "CBR", float32(5.1), "brown", int(138), int(600))}

	for _, veh := range vehicles {
		veh.move()
		veh.viewDetails()
		if veh, ok := veh.(*Car); 
		ok {
			veh.drift()
		}
	}
}
