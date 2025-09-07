import { useState, useEffect } from "react"
import { RatingSlider } from "../RatingSlider/RatingSlider"
import styles from "./RatingSliderList.module.css"

type RatingSliderListProps = {
    onTotalChange: (total: number) => void;
}

export const RatingSliderList = ({ onTotalChange }: RatingSliderListProps) => {

    const sliders = [
        { name: "Чистенько" },
        { name: "Сервис" },
        { name: "Скорость" },
        { name: "Место" },
        { name: "Культура речи" }
    ]

    const [values, setValues] = useState<number[]>(Array(sliders.length).fill(0));

    const handleSliderChange = (index: number, value: number) => {
        const updated = [...values];
        updated[index] = value;
        setValues(updated);
    };

    useEffect(() => {
        const total = values.reduce((sum, v) => sum + v, 0);
        onTotalChange(total);
    }, [values, onTotalChange]);

    return (
        <div className={styles.sliderList}>
            {sliders.map((slider, i) => (
                <RatingSlider
                    key={slider.name}
                    name={slider.name}
                    value={values[i]}
                    onChange={(value) => handleSliderChange(i, value)}
                />
            ))}
        </div>
    )
}