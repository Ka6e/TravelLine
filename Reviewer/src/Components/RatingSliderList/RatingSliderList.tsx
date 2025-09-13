import { RatingSlider } from "../RatingSlider/RatingSlider";
import styles from "./RatingSliderList.module.css";
import { useRatingSliderList } from "../../hooks/useRatingSliderList";

type RatingSliderListProps = {
    onTotalChange: (total: number) => void;
};

export const RatingSliderList = ({ onTotalChange }: RatingSliderListProps) => {
    const sliders = [
        { name: "Чистенько" },
        { name: "Сервис" },
        { name: "Скорость" },
        { name: "Место" },
        { name: "Культура речи" }
    ];

    const { values, handleChange } = useRatingSliderList(sliders.length, onTotalChange);

    return (
        <div className={styles.sliderList}>
            {sliders.map((slider, i) => (
                <RatingSlider
                    key={slider.name}
                    name={slider.name}
                    value={values[i]}
                    onChange={(value) => handleChange(i, value)}
                />
            ))}
        </div>
    );
};
