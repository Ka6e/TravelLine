import { FormView } from "./FormView";
import { useFormState } from "./useFormState";

type FormProps = {
    russianValue?: string;
    englishValue?: string;
    onSubmit: (russian: string, english: string) => void;
};

export const Form = ({ russianValue = "", englishValue = "", onSubmit }: FormProps) => {
    const state = useFormState(russianValue, englishValue, onSubmit);

    return <FormView {...state} />;
};
